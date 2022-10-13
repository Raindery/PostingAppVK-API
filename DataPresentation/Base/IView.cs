namespace DataPresentation.Base
{
    public interface IView
    {
        public event Action OnViewLoaded;

        public void Show();
        public void Close();
        public void LockView(bool locked);
    }
}
