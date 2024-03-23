using System.Drawing.Imaging;

namespace SaveScreens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string basePath = pathBox.Text;
            GetClipboardImage(out Image? image);

            try
            {
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                if (image  is null)
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
            }

            catch(Exception ex)
            {
                descriptionLabel.Text = ex.Message;
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
            for(int i = 0; i<length;i++)
            {
                var index = r.Next(symbols.Length);
                string strSub = str + symbols[index];
                str = strSub;
            }
            return str;

            
        }
    }
}