using DataPresentation.Base;

namespace DataPresentation.Common
{
    public interface IAuthorizationView : IView
    {
        public event Action OnChangePage;

        public string CurrentPageUrl { get; }
    }
}
