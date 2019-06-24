using MySql.Data.MySqlClient;
using System;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public static class DocumentGenerate
    {
        //public string DocumentType { get; set; }
        //public int Running { get; set; }

        /// <summary>
        /// Generate document no by document type
        /// </summary>
        /// <param name="documentType">REV,SO,INV,ISS</param>
        /// <returns></returns>
        public static string GetDocumentRunning(string documentType)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select running from document_generate");
                    sb.Append(" where document_type = @document_type");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("document_type", documentType);
                    var running = cmd.ExecuteScalar().ToString();

                    var documentNo = documentType + running.PadLeft(10 - documentType.Length, '0');




                    return documentNo;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetSwineLotNo(int plantId, DateTime productionDate, int queueNo)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    //var sb = new StringBuilder();
                    //sb.Append("select plant_id from plant");
                    //var cmd = new MySqlCommand(sb.ToString(), conn);
                    //var plant_id = cmd.ExecuteScalar().ToString();

                    var sb = new StringBuilder();
                    sb.Append("select running from document_generate");
                    sb.Append(" where document_type ='SWL'");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    var running = cmd.ExecuteScalar().ToString();

                    var year = DateTime.Today.ToString("yy");
                    var julian_date = DateTime.Today.DayOfYear.ToString().PadLeft(3, '0');
                    var day = productionDate.ToString("dd");
                    var month = productionDate.ToString("MM");
                    var documentNo = string.Format("{0}{1}{2}{3}{4}{5}", plantId, year, julian_date, queueNo, day, month);
                    return documentNo;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetProductLotNo(int plantId, DateTime productionDate)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();

                    //var sb = new StringBuilder();
                    //sb.Append("select plant_id from plant");
                    //var cmd = new MySqlCommand(sb.ToString(), conn);
                    //var plant_id = cmd.ExecuteScalar().ToString();

                    var sb = new StringBuilder();
                    sb.Append("select running from document_generate");
                    sb.Append(" where document_type ='PDL'");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    var running = cmd.ExecuteScalar().ToString();
                    var year = DateTime.Today.ToString("yy");
                    var julian_date = DateTime.Today.DayOfYear.ToString().PadLeft(3, '0');
                    var day = productionDate.ToString("dd");
                    var month = productionDate.ToString("MM");
                    var documentNo = string.Format("{0}{1}{2}{3}{4}", plantId, year, julian_date, day, month);
                    return documentNo;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

