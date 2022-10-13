using DataPresentation.Common;

namespace Views
{
    public partial class AuthorizationView : Form, IAuthorizationView
    {
        public event Action? OnChangePage;
        public event Action? OnViewLoaded;

        private readonly WebBrowser _webBrowser;
        private readonly string _vkApiAuthorizationUrl;

        public string CurrentPageUrl { get => _webBrowser.Url.ToString(); }

        
        public AuthorizationView(string vkApiAuthorizationUrl)
        {
            InitializeComponent();
            _vkApiAuthorizationUrl = vkApiAuthorizationUrl;
            _webBrowser = new WebBrowser();
            _webBrowser.DocumentCompleted += DocumentCompleted;
            SetupBrowser();
            Load += ViewLoad;
        }

        public new void Show()
        {
            _webBrowser.Url = new Uri(_vkApiAuthorizationUrl);
            ShowDialog();
        }

        public void LockView(bool locked)
        {
            Enabled = locked;
        }


        private void SetupBrowser()
        {
            _webBrowser.Parent = this;
            _webBrowser.Dock = DockStyle.Fill;
            _webBrowser.ScriptErrorsSuppressed = true;
            _webBrowser.ScrollBarsEnabled = false;
        }

        private void DocumentCompleted(object? sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if(OnChangePage != null)
                OnChangePage.Invoke();
        }

        private void ViewLoad(object? sender, EventArgs eventArgs)
        {
            if (OnViewLoaded != null)
                OnViewLoaded.Invoke();
        }
    }
}
