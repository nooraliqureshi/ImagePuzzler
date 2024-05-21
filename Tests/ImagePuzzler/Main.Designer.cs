namespace ImagePuzzler
{
    partial class Main
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
            pictureBox1 = new PictureBox();
            loadImage = new Button();
            shuffleResolve = new Button();
            resolvebtn = new Button();
            downloadImage = new Button();
            resetFields = new Button();
            exit = new Button();
            patternTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(142, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(450, 389);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseHover += pictureBox1_MouseHover;
            // 
            // loadImage
            // 
            loadImage.Location = new Point(12, 69);
            loadImage.Name = "loadImage";
            loadImage.Size = new Size(124, 51);
            loadImage.TabIndex = 1;
            loadImage.Text = "Load Image";
            loadImage.UseVisualStyleBackColor = true;
            loadImage.Click += loadImage_Click;
            // 
            // shuffleResolve
            // 
            shuffleResolve.Enabled = false;
            shuffleResolve.Location = new Point(12, 126);
            shuffleResolve.Name = "shuffleResolve";
            shuffleResolve.Size = new Size(124, 51);
            shuffleResolve.TabIndex = 2;
            shuffleResolve.Text = "Shuffle";
            shuffleResolve.UseVisualStyleBackColor = true;
            shuffleResolve.Click += shuffle_Click;
            // 
            // resolvebtn
            // 
            resolvebtn.Enabled = false;
            resolvebtn.Location = new Point(12, 179);
            resolvebtn.Name = "resolvebtn";
            resolvebtn.Size = new Size(124, 51);
            resolvebtn.TabIndex = 2;
            resolvebtn.Text = "Resolve";
            resolvebtn.UseVisualStyleBackColor = true;
            resolvebtn.Click += resolveBtn_Click;
            // 
            // downloadImage
            // 
            downloadImage.Location = new Point(12, 236);
            downloadImage.Name = "downloadImage";
            downloadImage.Size = new Size(124, 51);
            downloadImage.TabIndex = 3;
            downloadImage.Text = "Download Image";
            downloadImage.UseVisualStyleBackColor = true;
            downloadImage.Click += downloadImage_Click;
            // 
            // resetFields
            // 
            resetFields.Location = new Point(12, 293);
            resetFields.Name = "resetFields";
            resetFields.Size = new Size(124, 51);
            resetFields.TabIndex = 4;
            resetFields.Text = "Reset";
            resetFields.UseVisualStyleBackColor = true;
            resetFields.Click += resetFields_Click;
            // 
            // exit
            // 
            exit.Location = new Point(12, 350);
            exit.Name = "exit";
            exit.Size = new Size(124, 51);
            exit.TabIndex = 5;
            exit.Text = "Exit";
            exit.UseVisualStyleBackColor = true;
            exit.Click += exit_Click;
            // 
            // patternTextBox
            // 
            patternTextBox.Location = new Point(12, 12);
            patternTextBox.Name = "patternTextBox";
            patternTextBox.Size = new Size(124, 23);
            patternTextBox.TabIndex = 6;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 431);
            Controls.Add(patternTextBox);
            Controls.Add(exit);
            Controls.Add(resetFields);
            Controls.Add(downloadImage);
            Controls.Add(resolvebtn);
            Controls.Add(shuffleResolve);
            Controls.Add(loadImage);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ImagePuzzler";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button loadImage;
        private Button shuffleResolve;
        private Button resolvebtn;
        private Button downloadImage;
        private Button resetFields;
        private Button exit;
        private TextBox patternTextBox;
    }
}
