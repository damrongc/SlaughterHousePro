using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace SlaughterHouseServer
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MDIMain());
        }
    }
}
