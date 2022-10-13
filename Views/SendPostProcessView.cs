using DataPresentation.Common;

namespace Views
{
    public partial class SendPostProcessView : Form, ISendPostProcessView
    {
        private const int PROGRESS_BAR_INCREMENT_VALUE = 100;

        public event Action? OnViewLoaded;
        public event Action? OnViewClosed;

        
        public SendPostProcessView()
        {
            InitializeComponent();
            exitButton.Click += ClickCancel;
            FormClosed += CloseView;
        }

        public void LockView(bool locked)
        {
            throw new NotImplementedException();
        }

        public new void Show()
        {
            ShowDialog();
        }

        public void SendPostProcessSuccessLog(string groupName)
        {
            if (InvokeRequired)
            {
                postProcessLogTextBox.Invoke(() =>
                {
                    postProcessLogTextBox.Text += $"{groupName} ====== Success!{Environment.NewLine}";
                });
            }
            else
            {
                postProcessLogTextBox.Text += $"{groupName} ====== Success!{Environment.NewLine}";
            }
        }

        public void SendPostProcessErrorLog(string groupName, string errorText)
        {
            if (InvokeRequired)
            {
                postProcessLogTextBox.Invoke(() =>
                {
                    postProcessLogTextBox.Text += $"{groupName} ====== {errorText}{Environment.NewLine}";
                });
            }
            else
            {
                postProcessLogTextBox.Text += $"{groupName} ====== {errorText}{Environment.NewLine}";
            }   
        }


        private void ClickCancel(object? sender, EventArgs e)
        {
            Close();
        }

        private void CloseView(object? sender, EventArgs e)
        {
            if (OnViewClosed != null)
                OnViewClosed.Invoke();
        }

        public void SetupProgressBar(int urlsCount)
        {
            if (InvokeRequired)
            {
                postProcessProgressBar.Invoke(() =>
                {
                    postProcessProgressBar.Maximum = PROGRESS_BAR_INCREMENT_VALUE * urlsCount;
                });
            }
            else
            {
                postProcessProgressBar.Maximum = PROGRESS_BAR_INCREMENT_VALUE * urlsCount;
            }
        }

        public void IncrementProgressBar()
        {
            if (InvokeRequired)
            {
                postProcessProgressBar.Invoke(() =>
                {
                    postProcessProgressBar.Value += PROGRESS_BAR_INCREMENT_VALUE;
                });
            }
            else
            {
                postProcessProgressBar.Value += PROGRESS_BAR_INCREMENT_VALUE;
            }
        }
    }
}
