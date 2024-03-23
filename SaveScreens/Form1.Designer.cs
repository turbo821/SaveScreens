namespace SaveScreens
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveButton = new Button();
            pathBox = new TextBox();
            descriptionLabel = new Label();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new Point(121, 120);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // pathBox
            // 
            pathBox.Location = new Point(108, 82);
            pathBox.Name = "pathBox";
            pathBox.Size = new Size(100, 23);
            pathBox.TabIndex = 1;
            pathBox.TextChanged += pathBox_TextChanged;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Location = new Point(47, 53);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(229, 26);
            descriptionLabel.TabIndex = 2;
            descriptionLabel.Text = "Enter the folder for saving screenshots";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 185);
            Controls.Add(descriptionLabel);
            Controls.Add(pathBox);
            Controls.Add(saveButton);
            Name = "Form1";
            Text = "Saving screenshots to images";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private TextBox pathBox;
        private Label descriptionLabel;
    }
}
