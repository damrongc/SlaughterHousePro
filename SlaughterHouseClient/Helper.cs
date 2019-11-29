﻿using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace SlaughterHouseClient
{
    public static class Helper
    {

        public static string GetWeightIWX(string DataInvoke)
        {
            double num = 0.0;
            if (DataInvoke.Length == 38)
            {

                int scaleDecimal = DataInvoke.Substring(20, 2).ToInt32();
                int scaleDivision = (int)Math.Round(Math.Pow(10.0, unchecked(scaleDecimal)));

                string strFormatWt = scaleDecimal == 0 ? "#0" : "#0." + "0".PadRight(scaleDecimal, '0');
                short stateOfScale = DataInvoke.Substring(2, 1).ToInt16();
                //short stableWt = DataInvoke.Substring(2, 1).ToInt16();

                if (stateOfScale == 0)
                {
                    num = DataInvoke.Substring(14, 6).ToDouble() / scaleDivision;
                }
                else
                {
                    num = -1.0 * DataInvoke.Substring(14, 6).ToDouble() / scaleDivision;
                }
                return num.ToString(strFormatWt);

            }

            return num.ToString();
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static DataTable GetBarcode(long barcode_no)
        {
            try
            {

                using (var db = new SlaughterhouseEntities())
                {

                    var barcode = db.barcodes.Where(p => p.barcode_no == barcode_no).SingleOrDefault();
                    DataTable dt = new DataTable("Barcode");
                    dt.Columns.Add("barcode_no", typeof(string));
                    dt.Columns.Add("barcode_no_text", typeof(string));
                    dt.Columns.Add("barcode_info", typeof(string));
                    dt.Columns.Add("product_code", typeof(string));
                    dt.Columns.Add("product_name", typeof(string));
                    dt.Columns.Add("production_date", typeof(DateTime));
                    dt.Columns.Add("expired_date", typeof(DateTime));
                    dt.Columns.Add("lot_no", typeof(string));
                    dt.Columns.Add("qty", typeof(int));
                    dt.Columns.Add("qty_unit", typeof(string));
                    dt.Columns.Add("wgh", typeof(double));
                    dt.Columns.Add("wgh_unit", typeof(string));

                    DataRow dr = dt.NewRow();
                    dr["barcode_no"] = string.Format("*{0}*", barcode.barcode_no);
                    dr["barcode_no_text"] = barcode.barcode_no.ToString();
                    dr["barcode_info"] = string.Format("*00{0}{1}*", barcode.product_code, Convert.ToInt64(barcode.wgh * 10000).ToString().PadLeft(6, '0'));
                    dr["product_code"] = barcode.product_code;
                    dr["product_name"] = barcode.product.product_name;
                    dr["production_date"] = barcode.production_date;
                    dr["expired_date"] = barcode.production_date.AddDays(barcode.product.shelflife.ToString().ToDouble());
                    dr["lot_no"] = barcode.lot_no;
                    dr["qty"] = barcode.qty;
                    dr["qty_unit"] = barcode.product.unit_of_measurement.unit_name;
                    dr["wgh"] = barcode.wgh;
                    dr["wgh_unit"] = barcode.product.unit_of_measurement1.unit_name;
                    dt.Rows.Add(dr);

                    return dt;

                    //string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\Report\Rpt\"));//Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));
                    //dt.WriteXml(path + @"\xml\barcode.xml", XmlWriteMode.WriteSchema);

                }




            }
            catch (Exception)
            {

                throw;
            }

        }


    }


}
