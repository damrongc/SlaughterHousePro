
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

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
                    dt.Columns.Add("qr_code", typeof(byte[]));

                    DataRow dr = dt.NewRow();
                    //string barcode_no_text = string.Format("1{0}", barcode.barcode_no.ToString().PadLeft(12, '0'));
                    dr["barcode_no"] = string.Format("*{0}*", barcode.barcode_no);
                    dr["barcode_no_text"] = barcode.barcode_no;
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
                    dr["qr_code"] = GenerateQRCode(barcode.barcode_no.ToString());
                    dt.Rows.Add(dr);

                    //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report\xml\"));
                    //dt.WriteXml(path + @"barcode.xml", XmlWriteMode.WriteSchema);


                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static byte[] GenerateQRCode(string qrData)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions()
            {
                Width = 300,
                Height = 300,
                Margin = 0,
                PureBarcode = false
            };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(qrData);
            return GetRGBValues(bitmap);


        }

        public static Bitmap GenerateQRCodeImage(string qrData)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions()
            {
                Width = 100,
                Height = 100,
                Margin = 0,
                PureBarcode = false
            };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(qrData);
            return bitmap;


        }

        private static byte[] GetRGBValues(Bitmap bmp)
        {

            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
             bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
             bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes); bmp.UnlockBits(bmpData);

            return rgbValues;
        }


    }


}
