using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PostingAppVK_API.Views;

namespace PostingAppVK_API
{
    public partial class MainForm : Form
    {
        public event Action TokenReceived;

        public MainForm()
        {
            InitializeComponent();

            postContent.TextChanged += LockSendButton;
            sendPost.Click += SendPost;
            saveGroupsUrlButton.Click += SaveGroupList;
            authorizationButton.Click += RepeatAuthorization;
            TokenReceived += ChangeUserName;
       
            UserData.UpdateUserData();

            AddSavedGroupsToList();

            string token = UserData.GetUserDataFieldValue("token");
            if (token != string.Empty)
            {
                VkApi.SetToken(token);
                TokenReceived.Invoke();
            }  
        }

        public async void ChangeUserName()
        {
            string userNameString = await GetUserName();

            if(userNameString != null)
                userName.Text = userNameString;
            else
                userName.Text = "Необходимо войти";
        } 
        
        private async void SendPost(object sender, EventArgs e)
        {
            bool tokenExpired = await VkApi.IsTokenExpired();

            if (tokenExpired)
            {
                AuthorizationForm authorizationForm = new AuthorizationForm();

                var dialogResult = authorizationForm.ShowDialog();
                if (dialogResult == DialogResult.Cancel)
                {
                    string token = UserData.GetUserDataFieldValue("token");
                    if (token != string.Empty)
                    {
                        VkApi.SetToken(token);
                        TokenReceived.Invoke();
                    } 
                }
            }

            string[] screenNames = new string[groupsList.Rows.Count-1];
            int screenNameIndex = 0;
            foreach(DataGridViewRow row in groupsList.Rows)
            {
                if (row.Cells[groupUrl.Name].Value == null)
                    continue;

                string url = row.Cells[groupUrl.Name].Value.ToString();
                if (url == null || url == string.Empty)
                    continue;

                screenNames[screenNameIndex] = url.Replace("https://vk.com/", "");
                screenNameIndex++;
            }

            Enabled = false;

            ProgresAndLog progresAndLog = new ProgresAndLog(screenNames, postContent.Text);
            progresAndLog.ShowDialog();

            Enabled = true;
        }

        private void SaveGroupList(object sender, EventArgs e)
        {
            string groups = string.Empty;

            if (groupsList.Rows.Count <= 0)
                return;

            foreach (DataGridViewRow row in groupsList.Rows)
            {
                if (row.Cells[groupUrl.Name].Value == null)
                    continue;

                string url = row.Cells[groupUrl.Name].Value.ToString();

                if (url == null || url == string.Empty)
                    continue;

                url = url.Replace(" ", "");

                groups += $"{url};";
            }

            UserData.AddUserDataField("groups", groups);
            UserData.SaveUserData();
        }

        private void AddSavedGroupsToList()
        {
            string groups = UserData.GetUserDataFieldValue("groups");

            if (groups == string.Empty)
                return;

            string[] groupsUrls = groups.Split(';');

            for(int i = 0; i < groupsUrls.Length-1; i++)
            {
                groupsList.Rows.Add();
                groupsList.Rows[i].Cells[groupUrl.Name].Value = groupsUrls[i];
            }
        }

        private void LockSendButton(object sender, EventArgs e)
        {
            string postText = postContent.Text;

            postText = postText.Replace(" ", "");

            if (!postText.Equals(string.Empty))
                sendPost.Enabled = true;
            else
                sendPost.Enabled = false;
        }

        private void RepeatAuthorization(object sender, EventArgs e)
        {
            AuthorizationForm authorizationForm = new AuthorizationForm();
            var dialogResult = authorizationForm.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
            {
                string token = UserData.GetUserDataFieldValue("token");
                if (token != string.Empty)
                {
                    VkApi.SetToken(token);
                    TokenReceived.Invoke();
                }
                    

                
            }

            Enabled = true;
        }

        private async Task<string> GetUserName()
        {
            var response = await VkApi.GetProfileInfo();
            
            if(response.ResponseData != null)
            {
                string firsName = response.ResponseData["first_name"].ToString();
                string lastName = response.ResponseData["last_name"].ToString();

                return $"{firsName} {lastName}";
            }

            return null;
        }
    }
}
