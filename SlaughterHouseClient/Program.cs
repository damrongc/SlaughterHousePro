using System;
using System.Windows.Forms;

namespace SlaughterHouseClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form_SwineReceive());
            //Application.Run(new Form_CarcassReceive());
            Application.Run(new Form_Menu());
            //Application.Run(new Form_Lot(""));
        }
    }
}
