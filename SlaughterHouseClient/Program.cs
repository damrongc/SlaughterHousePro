using System;
using System.Windows.Forms;
using MySql.Data.Common;
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
            try
            {


                MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection();
                connection.ConnectionString = "Server=192.168.1.252;Database=slaughterhouse;Uid=root;Pwd=Pa$$w0rd@!9;SslMode=None;";
                connection.Open();

                //MessageBox.Show("Open success");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form_SwineReceive());
                //Application.Run(new Form_CarcassReceive());
                Application.Run(new Form_Menu());
                //Application.Run(new Form_Lot(""));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }




        }
    }
}
