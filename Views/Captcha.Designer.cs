namespace PostingAppVK_API.Views
{
    partial class Captcha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.captchaImage = new System.Windows.Forms.PictureBox();
            this.captchaKey = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.captchaImage)).BeginInit();
            this.SuspendLayout();
            // 
            // captchaImage
            // 
            this.captchaImage.Location = new System.Drawing.Point(216, 12);
            this.captchaImage.Name = "captchaImage";
            this.captchaImage.Size = new System.Drawing.Size(342, 229);
            this.captchaImage.TabIndex = 1;
            this.captchaImage.TabStop = false;
            // 
            // captchaKey
            // 
            this.captchaKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captchaKey.Location = new System.Drawing.Point(283, 287);
            this.captchaKey.Name = "captchaKey";
            this.captchaKey.Size = new System.Drawing.Size(164, 31);
            this.captchaKey.TabIndex = 2;
            // 
            // Captcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.captchaKey);
            this.Controls.Add(this.captchaImage);
            this.Name = "Captcha";
            this.Text = "Captcha";
            this.Load += new System.EventHandler(this.Captcha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.captchaImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox captchaImage;
        private System.Windows.Forms.TextBox captchaKey;
    }
}