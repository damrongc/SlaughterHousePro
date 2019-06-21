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

    }
}

