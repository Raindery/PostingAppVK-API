namespace DataPresentation.Base
{
    public interface IPresenter
    {
        public void Run();
    }

    public interface IPresenter<in TArg>
    {
        public void Run(TArg argument);
    }
}
