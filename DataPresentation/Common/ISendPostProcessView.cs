using DataPresentation.Base;

namespace DataPresentation.Common
{
    public interface ISendPostProcessView : IView
    {
        public event Action OnViewClosed;

        public void SendPostProcessSuccessLog(string groupName);
        public void SendPostProcessErrorLog(string groupName, string errorText);
        public void SetupProgressBar(int urlsCount);
        public void IncrementProgressBar();
    }
}
