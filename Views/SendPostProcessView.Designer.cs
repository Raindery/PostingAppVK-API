namespace Views
{
    partial class SendPostProcessView
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
            this.postProcessLogTextBox = new System.Windows.Forms.TextBox();
            this.postProcessProgressBar = new System.Windows.Forms.ProgressBar();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // postProcessLogTextBox
            // 
            this.postProcessLogTextBox.Location = new System.Drawing.Point(38, 39);
            this.postProcessLogTextBox.Multiline = true;
            this.postProcessLogTextBox.Name = "postProcessLogTextBox";
            this.postProcessLogTextBox.ReadOnly = true;
            this.postProcessLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.postProcessLogTextBox.Size = new System.Drawing.Size(671, 282);
            this.postProcessLogTextBox.TabIndex = 0;
            // 
            // postProcessProgressBar
            // 
            this.postProcessProgressBar.Location = new System.Drawing.Point(38, 350);
            this.postProcessProgressBar.Name = "postProcessProgressBar";
            this.postProcessProgressBar.Size = new System.Drawing.Size(671, 31);
            this.postProcessProgressBar.TabIndex = 1;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exitButton.Location = new System.Drawing.Point(595, 405);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(114, 35);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // SendPostProcessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 452);
            this.ControlBox = false;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.postProcessProgressBar);
            this.Controls.Add(this.postProcessLogTextBox);
            this.Name = "SendPostProcessView";
            this.Text = "Отправление";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox postProcessLogTextBox;
        private ProgressBar postProcessProgressBar;
        private Button exitButton;
    }
}