using DataPresentation.Base;

namespace DataPresentation.Common
{
    public abstract class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IApplicationController ApplicationController { get; private set; }


        protected BasePresenter(IApplicationController applicationController, TView view)
        {
            ApplicationController = applicationController;
            View = view;
        }

        public void Run()
        {
            View.Show();
        }
    }

    public abstract class BasePresenter<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IApplicationController ApplicationController { get; private set; }

        protected BasePresenter(IApplicationController applicationController, TView view)
        {
            ApplicationController = applicationController;
            View = view;
        }

        public abstract void Run(TArg argumnet);
    }
}
