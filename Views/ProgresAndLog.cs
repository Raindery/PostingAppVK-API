using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostingAppVK_API.Views
{
    public partial class ProgresAndLog : Form
    {
        private event Action<string, string> ProgessChanged;
        private event Action<bool> ProcessFinished;
        private readonly string[] _groupsName;
        private readonly string _postContent;

        public ProgresAndLog(string[] groupsNames, string postContent)
        {
            _groupsName = groupsNames;
            _postContent = postContent;

            ProgessChanged += WriteLog;
            ProcessFinished += UnlockExitButton;
            InitializeComponent();
        }

        public async Task SendPostInGroups()
        {
            Invoke(ProcessFinished, false);

            foreach (string screenName in _groupsName)
            {
                int groupId;
                var getidResponse = await VkApi.GetId(screenName);

                if (getidResponse.ErrorData == null)
                {
                    if (getidResponse.ResponseData != null)
                        groupId = -int.Parse(getidResponse.ResponseData["object_id"]);
                    else
                        groupId = 0;
                }
                else
                {
                    Invoke(ProgessChanged, screenName, getidResponse.ErrorData["error_msg"].ToString());
                    continue;
                }

                await Task.Delay(350);

                var sendPostResponse = await VkApi.SendPostToGroup(groupId, _postContent);
                if (sendPostResponse.ResponseData != null)
                {
                    Invoke(ProgessChanged, screenName, "Success");
                }
                else
                {
                    int errorCode = int.Parse(sendPostResponse.ErrorData["error_code"].ToString());

                    if (errorCode == 14)
                    {
                        string captchaUrl = sendPostResponse.ErrorData["captcha_img"].ToString();
                        Captcha captcha = new Captcha(captchaUrl);
                        var captchaDialogResult = captcha.ShowDialog();

                        if (captchaDialogResult == DialogResult.Cancel)
                        {
                            Invoke(ProgessChanged, screenName, "Captcha exit");
                            continue;
                        }
                    }
                    else if (errorCode == 6)
                    {
                        Invoke(ProgessChanged, screenName, sendPostResponse.ErrorData["error_msg"].ToString());
                        await Task.Delay(600);
                        continue;
                    }
                    else
                    {
                        Invoke(ProgessChanged, screenName, sendPostResponse.ErrorData["error_msg"].ToString());
                        continue;
                    }
                }
            }

            Invoke(ProcessFinished, true);
        }

        private void ProgresAndLog_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100 * _groupsName.Length;
            Task.Run(SendPostInGroups);
        }

        private void WriteLog(string groupName, string logMessage)
        {
            textBox1.Text += $"{groupName} ----- {logMessage}{Environment.NewLine}";
            progressBar1.Value += 100;
        }

        private void UnlockExitButton(bool unlock)
        {
            exitButton.Enabled = unlock;
        }
    }
}
