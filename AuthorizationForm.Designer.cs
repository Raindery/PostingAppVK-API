namespace PostingAppVK_API
{
    partial class AuthorizationForm
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
            this.authorizationWeb = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // authorizationWeb
            // 
            this.authorizationWeb.AllowWebBrowserDrop = false;
            this.authorizationWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authorizationWeb.IsWebBrowserContextMenuEnabled = false;
            this.authorizationWeb.Location = new System.Drawing.Point(0, 0);
            this.authorizationWeb.MinimumSize = new System.Drawing.Size(20, 20);
            this.authorizationWeb.Name = "authorizationWeb";
            this.authorizationWeb.ScriptErrorsSuppressed = true;
            this.authorizationWeb.ScrollBarsEnabled = false;
            this.authorizationWeb.Size = new System.Drawing.Size(800, 450);
            this.authorizationWeb.TabIndex = 0;
            this.authorizationWeb.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.authorizationWeb);
            this.Name = "AuthorizationForm";
            this.Text = "AuthorizationForm";
            this.Load += new System.EventHandler(this.AuthorizationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser authorizationWeb;
    }
}