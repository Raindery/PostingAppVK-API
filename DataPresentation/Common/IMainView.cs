using DataPresentation.Base;

namespace DataPresentation.Common
{
    public interface IMainView : IView
    {
        public event Action OnSave;
        public event Action OnSendPost;
        public event Action OnAuthClick;
        public event Action OnLogoutClick;

        public string PostContent { get; }
        public List<string> UrlList { get; }
        public string Username { get; }


        public void ShowError(string errorString);
        public void SetUrlList(List<string> urlList);
        public void SetPostContent(string postContent);
        public void SetUserData(string username);
        public void RemoveUserData();
    }
}
