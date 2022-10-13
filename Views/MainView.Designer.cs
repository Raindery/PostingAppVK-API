namespace Views
{
    partial class MainView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupUrlsLabel = new System.Windows.Forms.Label();
            this.groupUrlsGrid = new System.Windows.Forms.DataGridView();
            this.urlColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postContentTextBox = new System.Windows.Forms.TextBox();
            this.postContentLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.sendPostButton = new System.Windows.Forms.Button();
            this.authButton = new System.Windows.Forms.Button();
            this.userDataPanel = new System.Windows.Forms.Panel();
            this.logoutButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupUrlsGrid)).BeginInit();
            this.userDataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupUrlsLabel
            // 
            this.groupUrlsLabel.AutoSize = true;
            this.groupUrlsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupUrlsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupUrlsLabel.Location = new System.Drawing.Point(70, 75);
            this.groupUrlsLabel.Name = "groupUrlsLabel";
            this.groupUrlsLabel.Size = new System.Drawing.Size(82, 25);
            this.groupUrlsLabel.TabIndex = 0;
            this.groupUrlsLabel.Text = "Группы";
            this.groupUrlsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupUrlsGrid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.groupUrlsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.groupUrlsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupUrlsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.urlColumn});
            this.groupUrlsGrid.Location = new System.Drawing.Point(70, 112);
            this.groupUrlsGrid.Name = "groupUrlsGrid";
            this.groupUrlsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.groupUrlsGrid.RowTemplate.Height = 25;
            this.groupUrlsGrid.Size = new System.Drawing.Size(341, 363);
            this.groupUrlsGrid.TabIndex = 1;
            // 
            // urlColumn
            // 
            this.urlColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.urlColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.urlColumn.HeaderText = "Ссылка на группу";
            this.urlColumn.Name = "urlColumn";
            this.urlColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.urlColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // postContentTextBox
            // 
            this.postContentTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.postContentTextBox.Location = new System.Drawing.Point(515, 112);
            this.postContentTextBox.Multiline = true;
            this.postContentTextBox.Name = "postContentTextBox";
            this.postContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.postContentTextBox.Size = new System.Drawing.Size(455, 414);
            this.postContentTextBox.TabIndex = 2;
            this.postContentTextBox.Text = "Это пост";
            // 
            // postContentLabel
            // 
            this.postContentLabel.AutoSize = true;
            this.postContentLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.postContentLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.postContentLabel.Location = new System.Drawing.Point(515, 75);
            this.postContentLabel.Name = "postContentLabel";
            this.postContentLabel.Size = new System.Drawing.Size(57, 25);
            this.postContentLabel.TabIndex = 3;
            this.postContentLabel.Text = "Пост";
            this.postContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveButton.Location = new System.Drawing.Point(70, 491);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(138, 35);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // sendPostButton
            // 
            this.sendPostButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendPostButton.Location = new System.Drawing.Point(515, 544);
            this.sendPostButton.Name = "sendPostButton";
            this.sendPostButton.Size = new System.Drawing.Size(138, 56);
            this.sendPostButton.TabIndex = 5;
            this.sendPostButton.Text = "Отправить пост в группы";
            this.sendPostButton.UseVisualStyleBackColor = true;
            // 
            // authButton
            // 
            this.authButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.authButton.Location = new System.Drawing.Point(843, 57);
            this.authButton.Name = "authButton";
            this.authButton.Size = new System.Drawing.Size(127, 35);
            this.authButton.TabIndex = 6;
            this.authButton.Text = "Войти";
            this.authButton.UseVisualStyleBackColor = true;
            this.authButton.Visible = false;
            // 
            // userDataPanel
            // 
            this.userDataPanel.Controls.Add(this.logoutButton);
            this.userDataPanel.Controls.Add(this.usernameLabel);
            this.userDataPanel.Location = new System.Drawing.Point(838, 6);
            this.userDataPanel.Name = "userDataPanel";
            this.userDataPanel.Size = new System.Drawing.Size(200, 100);
            this.userDataPanel.TabIndex = 7;
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logoutButton.Location = new System.Drawing.Point(3, 53);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(115, 30);
            this.logoutButton.TabIndex = 8;
            this.logoutButton.Text = "Выход";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usernameLabel.Location = new System.Drawing.Point(3, 7);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(165, 23);
            this.usernameLabel.TabIndex = 8;
            this.usernameLabel.Text = "Имя пользователя";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 639);
            this.Controls.Add(this.userDataPanel);
            this.Controls.Add(this.authButton);
            this.Controls.Add(this.sendPostButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.postContentLabel);
            this.Controls.Add(this.postContentTextBox);
            this.Controls.Add(this.groupUrlsGrid);
            this.Controls.Add(this.groupUrlsLabel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Text = "VKPostingApp";
            ((System.ComponentModel.ISupportInitialize)(this.groupUrlsGrid)).EndInit();
            this.userDataPanel.ResumeLayout(false);
            this.userDataPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label groupUrlsLabel;
        private DataGridView groupUrlsGrid;
        private TextBox postContentTextBox;
        private Label postContentLabel;
        private Button saveButton;
        private Button sendPostButton;
        private Button authButton;
        private DataGridViewTextBoxColumn urlColumn;
        private Panel userDataPanel;
        private Button logoutButton;
        private Label usernameLabel;
    }
}