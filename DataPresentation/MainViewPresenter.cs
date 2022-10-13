using DataPresentation.Common;
using DataPresentation.Data;
using UserDataService;

namespace DataPresentation
{
    public class MainViewPresenter : BasePresenter<IMainView, UserData>
    {
        private UserData? _userData;
        private readonly IUserDataService _userDataService;


        public MainViewPresenter(IApplicationController applicationController, IMainView mainView, IUserDataService userDataService)
            :base(applicationController, mainView)
        {
            _userDataService = userDataService;

            View.OnSave += SaveUrlsToUserDataFile;
            View.OnSave += SavePostContentToUserDataFile;
            View.OnSendPost += SendPost;
            View.OnAuthClick += Authorization;
            View.OnLogoutClick += Logout;
        }

        public override void Run(UserData userData)
        {
            _userData = userData;
            UpdateUserDataStatus();
            SetUrlsFromUserDataFile();
            SetPostContentFromUserDataFile();
            View.Show();
        }



        private void SaveUrlsToUserDataFile()
        {
            List<string> urlsList = View.UrlList;

            if (urlsList.Count <= 0)
                return;

            string stringUrls = string.Empty;
            foreach (string urlString in urlsList)
            {
                stringUrls += $"{urlString};";
            }

            if (!_userDataService.DataFileExsist())
                _userDataService.CreateDataFile();

            _userDataService.AddUserDataString(UserDataNames.GROUP_URLS, stringUrls);
            _userDataService.SaveUserData();
        }

        private void SavePostContentToUserDataFile()
        {
            if (!_userDataService.DataFileExsist())
                _userDataService.CreateDataFile();

            _userDataService.AddUserDataString(UserDataNames.POST_CONTENT, View.PostContent);
            _userDataService.SaveUserData();
        }

        private void SetUrlsFromUserDataFile()
        {
            string? urlsString = _userDataService.GetUserDataField(UserDataNames.GROUP_URLS);
            if (urlsString == null)
                return;

            string[] urls = urlsString.Split(';');
            var urlList = new List<string>();
            for (int i = 0; i < urls.Length; i++)
            {
                if (urls[i] == string.Empty || urls[i] == " ")
                    continue;

                urlList.Add(urls[i]);
            }

            View.SetUrlList(urlList);
        }

        private void SetPostContentFromUserDataFile()
        {
            string? postContent = _userDataService.GetUserDataField(UserDataNames.POST_CONTENT);

            if (postContent != null)
                View.SetPostContent(postContent);
        }

        private void SendPost()
        {
            if (View.PostContent == null || View.PostContent == string.Empty)
            {
                View.ShowError("Прежде чем отправить пост, необходимо его написать:)");
                return;
            }

            if(View.UrlList.Count <= 0)
            {
                View.ShowError("Добавьте хотя-бы одну группу, прежде чем отправить пост");
                return;
            }

            string? token = _userDataService.GetUserDataField(UserDataNames.VK_API_TOKEN);
            if (token == null)
                Authorization();

            token = _userDataService.GetUserDataField(UserDataNames.VK_API_TOKEN);
            if(token == null)
            {
                View.ShowError("Не удалось получить токен. Отправка не возможна!");
                return;
            }

            View.LockView(true);
            var sendPostData = new SendPostData(View.UrlList, View.PostContent);
            ApplicationController.Run<SendPostProcessPresenter, SendPostData>(sendPostData);
            View.LockView(false);            
        }

        private void Authorization()
        {
            if (_userData == null)
                _userData = new UserData();

            View.LockView(true);
            ApplicationController.Run<AuthorizationPresenter, UserData>(_userData);
            View.LockView(false);

            UpdateUserDataStatus();
        }

        private void Logout()
        {
            string? token = _userDataService.GetUserDataField(UserDataNames.VK_API_TOKEN);
            if (token != null || token != string.Empty)
                _userDataService.AddUserDataString(UserDataNames.VK_API_TOKEN, "");
            _userDataService.SaveUserData();

            _userData = new UserData();

            UpdateUserDataStatus();
        }

        private void UpdateUserDataStatus()
        {
            if (_userData == null)
                _userData = new UserData();

            if (_userData.Firstname != null && _userData.Lastname != null)
                View.SetUserData($"{_userData.Firstname} {_userData.Lastname}");
            else
                View.RemoveUserData();
        } 
    }
}
