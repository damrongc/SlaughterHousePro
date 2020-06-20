using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.Common;
using Newtonsoft.Json;
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
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

                //DataTable dt = Helper.GetBarcode(10000000008);

                //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report\xml\"));
                //dt.WriteXml(path + @"barcode.xml", XmlWriteMode.WriteSchema);



                //System.Data.DataTable dt = new System.Data.DataTable();
                //dt.Columns.Add("ORG_CODE");
                //System.Data.DataRow dr;
                //dr = dt.NewRow();
                //dr["ORG_CODE"] = "SSSS";
                //dt.Rows.Add(dr);

                //var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);


                //MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection();
                //connection.ConnectionString = "Server=192.168.1.252;Database=slaughterhouse;Uid=root;Pwd=Pa$$w0rd@!9;SslMode=None;";
                //connection.Open();

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
