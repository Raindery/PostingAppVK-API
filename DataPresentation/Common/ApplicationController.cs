using DataPresentation.Base;
using LightInject;

namespace DataPresentation.Common
{
    public class ApplicationController : IApplicationController
    {
        private readonly ServiceContainer _container;

        public ApplicationController(ServiceContainer container)
        {
            _container = container;
            _container.RegisterInstance<IApplicationController>(this);
        }

        public IApplicationController RegisterInstance<TArgument>(TArgument instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }

        public IApplicationController RegisterService<TService, TImplementation>() where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>();
            return this;
        }

        public IApplicationController RegisterView<TView, TImplementation>()
            where TView : IView
            where TImplementation : class, TView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            if (!_container.CanGetInstance(typeof(TPresenter), string.Empty))
                _container.Register<TPresenter>();

            TPresenter presenter = _container.GetInstance<TPresenter>();
            presenter.Run();
        }

        public void Run<TPresenter, TArgument>(TArgument argument) 
            where TPresenter : class, IPresenter<TArgument>
            where TArgument : class
        {
            if (!_container.CanGetInstance(typeof(TPresenter), string.Empty))
                _container.Register<TPresenter>();

            var presenter = _container.GetInstance<TPresenter>();

            presenter.Run(argument);
        }
    }
}
