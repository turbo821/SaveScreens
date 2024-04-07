using System.Drawing.Imaging;

namespace SaveScreens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            string basePath = pathBox.Text;
            GetClipboardImage(out Image? image);

            try
            {
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                if (image is null)
                {
                    throw new Exception("Screenshot not in clipboard");
                }

                string path = basePath + "/" + GenerateRandomString(5) + image.GetHashCode() + ".png";

                if (File.Exists(path))
                {
                    throw new Exception("Reply please");
                }

                using (FileStream fstream = new FileStream(path, FileMode.Create))
                {
                    image.Save(fstream, ImageFormat.Png);
                    descriptionLabel.Text = "Screenshot saved, go retry!";
                    Clipboard.Clear();
                }
                using (StreamWriter writer = new StreamWriter("close_path.log", false))
                {
                    writer.WriteLine(pathBox.Text);
                }
            }

            catch (Exception ex)
            {
                descriptionLabel.Text = ex.Message;
            }
            finally
            {
                descriptionLabel.Location = new Point(85, 53);
                label1.BackColor = Color.LimeGreen;
                await Task.Delay(2000);
                label1.BackColor = SystemColors.Control;
            }
        }

        private static void GetClipboardImage(out Image? returnImage)
        {
            returnImage = null;
            if (Clipboard.ContainsImage())
            {
                returnImage = Clipboard.GetImage();
            }
        }

        private static string GenerateRandomString(int length)
        {
            string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random r = new Random();
            string str = "";
            for (int i = 0; i < length; i++)
            {
                var index = r.Next(symbols.Length);
                string strSub = str + symbols[index];
                str = strSub;
            }
            return str;


        }

        private void pathBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("close_path.log"))
            {
                File.Create("close_path.log");
            }
            try
            {
                using (StreamReader reader = new StreamReader("close_path.log"))
                {
                    pathBox.Text = reader.ReadLine();
                }
            }
            catch { }
        }
    }
}
