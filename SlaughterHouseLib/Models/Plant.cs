using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class Plant
    {
        public int PlantId { get; set; }
        public DateTime ProductionDate { get; set; }
        public string PlantName { get; set; }
        public string Address { get; set; }
    }

    public class PlantController
    {
        public static Plant GetPlant()
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from plant");
                    //sb.Append(" where plant_id = @plant_id");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    //cmd.Parameters.AddWithValue("plant_id", plantId);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    return new Plant
                    {
                        PlantId = (int)ds.Tables[0].Rows[0]["plant_id"],
                        ProductionDate = (DateTime)ds.Tables[0].Rows[0]["production_date"],
                    };

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
