using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace SlaughterHouseLib.Models
{
    public class TruckType
    {
        public int TruckTypeId { get; set; }
        public string TruckTypeDesc { get; set; }
    }
    public static class TruckTypeController
    {
        public static List<TruckType> GetAllTruckTypes()
        {
            try
            {
                List<TruckType> truckTypes = new List<TruckType>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT * FROM truck_type WHERE active=1";
                    var cmd = new MySqlCommand(sql, conn);
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        truckTypes.Add(new TruckType
                        {
                            TruckTypeId = item["truck_type_id"].ToString().ToInt16(),
                            TruckTypeDesc = item["truck_type_desc"].ToString(),
                        });
                    }
                    return truckTypes;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
