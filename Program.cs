using System;
using System.Windows.Forms;

namespace PostingAppVK_API
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserData.CreateDataFileIfNotExsist();

            Application.Run(new MainForm());
        }
    }
}
