using DataPresentation.Base;

namespace DataPresentation.Common
{
    public interface IApplicationController
    {
        public IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView;
        public IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;
        public IApplicationController RegisterInstance<TArgument>(TArgument instance);
        public void Run<TPresenter>() where TPresenter : class, IPresenter;
        public void Run<TPresenter, TArgument>(TArgument argument)
            where TPresenter : class, IPresenter<TArgument>
            where TArgument : class;
    }
}
