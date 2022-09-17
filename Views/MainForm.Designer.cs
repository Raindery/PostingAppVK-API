using System;
using System.ComponentModel;

namespace PostingAppVK_API
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.groupsList = new System.Windows.Forms.DataGridView();
            this.groupUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postContent = new System.Windows.Forms.TextBox();
            this.sendPost = new System.Windows.Forms.Button();
            this.saveGroupsUrlButton = new System.Windows.Forms.Button();
            this.authorizationButton = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupsList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupsList
            // 
            this.groupsList.AllowUserToOrderColumns = true;
            this.groupsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupUrl});
            this.groupsList.Location = new System.Drawing.Point(30, 72);
            this.groupsList.Name = "groupsList";
            this.groupsList.Size = new System.Drawing.Size(339, 296);
            this.groupsList.TabIndex = 4;
            // 
            // groupUrl
            // 
            this.groupUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.groupUrl.HeaderText = "Ссылка";
            this.groupUrl.Name = "groupUrl";
            this.groupUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.groupUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // postContent
            // 
            this.postContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postContent.Location = new System.Drawing.Point(473, 72);
            this.postContent.Multiline = true;
            this.postContent.Name = "postContent";
            this.postContent.Size = new System.Drawing.Size(432, 296);
            this.postContent.TabIndex = 5;
            // 
            // sendPost
            // 
            this.sendPost.Enabled = false;
            this.sendPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendPost.Location = new System.Drawing.Point(473, 384);
            this.sendPost.Name = "sendPost";
            this.sendPost.Size = new System.Drawing.Size(111, 34);
            this.sendPost.TabIndex = 6;
            this.sendPost.Text = "Отправить";
            this.sendPost.UseVisualStyleBackColor = true;
            // 
            // saveGroupsUrlButton
            // 
            this.saveGroupsUrlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveGroupsUrlButton.Location = new System.Drawing.Point(30, 384);
            this.saveGroupsUrlButton.Name = "saveGroupsUrlButton";
            this.saveGroupsUrlButton.Size = new System.Drawing.Size(111, 34);
            this.saveGroupsUrlButton.TabIndex = 7;
            this.saveGroupsUrlButton.Text = "Сохранить";
            this.saveGroupsUrlButton.UseVisualStyleBackColor = true;
            // 
            // authorizationButton
            // 
            this.authorizationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorizationButton.Location = new System.Drawing.Point(776, 12);
            this.authorizationButton.Name = "authorizationButton";
            this.authorizationButton.Size = new System.Drawing.Size(129, 40);
            this.authorizationButton.TabIndex = 8;
            this.authorizationButton.Text = "Повторная Авторизация";
            this.authorizationButton.UseVisualStyleBackColor = true;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.userName.Location = new System.Drawing.Point(30, 23);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(147, 17);
            this.userName.TabIndex = 9;
            this.userName.Text = "Необходимо войти";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 437);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.authorizationButton);
            this.Controls.Add(this.saveGroupsUrlButton);
            this.Controls.Add(this.sendPost);
            this.Controls.Add(this.postContent);
            this.Controls.Add(this.groupsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.groupsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView groupsList;
        private System.Windows.Forms.TextBox postContent;
        private System.Windows.Forms.Button sendPost;
        private System.Windows.Forms.Button saveGroupsUrlButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupUrl;
        private System.Windows.Forms.Button authorizationButton;
        private System.Windows.Forms.Label userName;
    }
}