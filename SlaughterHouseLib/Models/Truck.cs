using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SlaughterHouseLib.Models
{
    public class Truck
    {
        public string TruckNo { get; set; }
        public string Driver { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public static class TruckController
    {
        public static List<Truck> GetAllTrucks()
        {
            try
            {
                List<Truck> Trucks = new List<Truck>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM truck WHERE active=1");
                    sb.Append(" ORDER BY truck_no asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        Trucks.Add(new Truck
                        {
                            TruckNo =  item["truck_no"].ToString(),
                            Driver = item["driver"].ToString(),
                        });
                    }

                    return Trucks;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataTable  GetAllTrucks(string keyword)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from truck");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" where driver like @driver");

                    }

                    sb.Append(" order by driver asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("driver", string.Format("%{0}%", keyword));
                    }


                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    return ds.Tables[0];
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string GetTruckNoFromTransport(string orderNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append(" select truck_no from transport");
                    sb.Append(" where ref_document_no = @ref_document_no");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("ref_document_no", orderNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    string res = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        res = ds.Tables[0].Rows[0]["truck_no"].ToString() != "" ? ds.Tables[0].Rows[0]["truck_no"].ToString() : "";
                    }

                    return res;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

            public static Truck GetTruck(string truckNo)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from truck");
                    sb.Append(" where truck_no = @truck_no");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("truck_no", truckNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var farm = new Truck();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Truck
                        {

                            TruckNo = ds.Tables[0].Rows[0]["truck_no"].ToString(),
                            Driver = ds.Tables[0].Rows[0]["driver"].ToString(),
                            Active = (bool)ds.Tables[0].Rows[0]["active"],
                            CreateAt = (DateTime)ds.Tables[0].Rows[0]["create_at"],
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Insert(Truck Truck)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO slaughterhouse.truck
                                (truck_no,
                                driver,
                                active, 
                                create_by )
                                VALUES (@truck_no,
                                @driver,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("truck_no", Truck.TruckNo);
                    cmd.Parameters.AddWithValue("driver", Truck.Driver);
                    cmd.Parameters.AddWithValue("active", Truck.Active);
                    cmd.Parameters.AddWithValue("create_by", Truck.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Update(Truck Truck)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE truck
                                SET driver=@driver,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE truck_no=@truck_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("truck_no", Truck.TruckNo);
                    cmd.Parameters.AddWithValue("driver", Truck.Driver);
                    cmd.Parameters.AddWithValue("active", Truck.Active);
                    cmd.Parameters.AddWithValue("modified_by", Truck.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
