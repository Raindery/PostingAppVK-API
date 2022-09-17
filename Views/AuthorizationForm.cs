using System;
using System.Windows.Forms;

namespace PostingAppVK_API
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            authorizationWeb.DocumentCompleted += AuthorizationBrowser_DocumentComplited;
            authorizationWeb.Navigate(VkApi.GetAuthorezationUrl());
        }

        private void AuthorizationBrowser_DocumentComplited(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            if(e.Url.ToString().Contains("access_token"))
            {
                string argumentsString = e.Url.ToString().Substring(e.Url.ToString().IndexOf('#') + 1);
                string[] argumentsAndValues = argumentsString.Split('=', '&');
                int tokenIndex = Array.IndexOf(argumentsAndValues, "access_token");
                string token = argumentsAndValues[tokenIndex+1];

                UserData.AddUserDataField("token", token);
                UserData.SaveUserData();

                Close();
            }
        }
    }
}
