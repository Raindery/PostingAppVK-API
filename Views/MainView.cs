using DataPresentation.Common;

namespace Views
{
    public partial class MainView : Form, IMainView
    {
        public event Action? OnSave;
        public event Action? OnSendPost;
        public event Action? OnViewLoaded;
        public event Action? OnAuthClick;
        public event Action? OnLogoutClick;

        public string PostContent
        {
            get
            {
                if (postContentTextBox.Text.Length <= 0)
                    return string.Empty;

                return postContentTextBox.Text;
            }

            protected set
            {
                if (value != null)
                    postContentTextBox.Text = value;
            }

        }
        public List<string> UrlList
        {
            get
            {
                if (groupUrlsGrid.Rows.Count <= 0)
                    return new List<string>();

                var urls = new List<string>();
                foreach(DataGridViewRow urlsRow in groupUrlsGrid.Rows)
                {
                    string? urlValue = urlsRow.Cells[urlColumn.Name].Value?.ToString();
                    if (urlValue == null || urlValue.Equals(string.Empty))
                        continue;

                    urlValue = urlValue.Replace(" ", "");
                    urls.Add(urlValue);
                }

                return urls;
            }

            private set
            {
                foreach(string url in value)
                {
                    int indexRow = groupUrlsGrid.Rows.Add();
                    groupUrlsGrid.Rows[indexRow].Cells[urlColumn.Name].Value = url;
                }
            }
        }
        public string Username
        {
            get
            {
                return usernameLabel.Text;
            }
        }

        public MainView()
        {
            InitializeComponent();
            Load += ViewLoad;
            saveButton.Click += SaveClick;
            sendPostButton.Click += SendPostClick;
            authButton.Click += AuthClick;
            logoutButton.Click += LogoutClick;
            postContentTextBox.TextChanged += PostContentChanged;
               
            DisableSendButtonIfPostEmpty();
        }

        public void ShowError(string errorString)
        {
            LockView(true);
            MessageBox.Show(errorString, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LockView(false);
        }

        public void SetUrlList(List<string> urlList)
        {
            if (urlList.Count <= 0)
                return;

            groupUrlsGrid.Rows.Clear();
            UrlList = urlList;
        }

        public void SetPostContent(string postContent)
        {
            PostContent = postContent;
        }

        public void SetUserData(string username)
        {
            SetUserDataPanelVisible(true);
            usernameLabel.Text = username;
        }

        public void RemoveUserData()
        {
            SetUserDataPanelVisible(false);
        }

        public new void Show()
        {
            Application.Run(this);
        }

        public void LockView(bool locked)
        {
            Enabled = !locked;
        }


        private void SaveClick(object? sender, EventArgs e)
        {
            if (OnSave != null)
                OnSave.Invoke();
        }

        private void SendPostClick(object? sender, EventArgs e)
        {
            if (OnSendPost != null)
                OnSendPost.Invoke();
        }

        private void ViewLoad(object? sender, EventArgs e)
        {
            if (OnViewLoaded != null)
                OnViewLoaded.Invoke();
        }

        private void AuthClick(object? sender, EventArgs e)
        {
            if (OnAuthClick != null)
                OnAuthClick.Invoke();
        }

        private void LogoutClick(object? sender, EventArgs e)
        {
            if (OnLogoutClick != null)
                OnLogoutClick.Invoke();
        }

        private void PostContentChanged(object? sender, EventArgs e)
        {
            DisableSendButtonIfPostEmpty();
        }

        private void SetUserDataPanelVisible(bool visible)
        {
            userDataPanel.Visible = visible;
            authButton.Visible = !visible;
        }

        private void DisableSendButtonIfPostEmpty()
        {
            if (postContentTextBox == null || postContentTextBox.TextLength <= 0)
                sendPostButton.Enabled = false;
            else
                sendPostButton.Enabled = true;
        }
    }
}
