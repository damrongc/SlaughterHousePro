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
        public int TruckTypeId { get; set; }
        public string TruckType { get; set; }
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
                    var sql = @"SELECT a.truck_no,a.driver,b.truck_type_desc
                                    FROM truck a,truck_type b
                                    WHERE a.truck_type_id =b.truck_type_id
                                    AND a.active=1
                                    ORDER BY a.truck_no ASC";
                    var cmd = new MySqlCommand(sql, conn);
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        Trucks.Add(new Truck
                        {
                            TruckNo = item["truck_no"].ToString(),
                            TruckType = item["truck_type_desc"].ToString(),
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

        public static List<Truck> GetAllTrucks(int typeId)
        {
            try
            {
                List<Truck> Trucks = new List<Truck>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT a.truck_no,a.driver,b.truck_type_desc
                                    FROM truck a,truck_type b
                                    WHERE a.truck_type_id =b.truck_type_id
                                    AND a.truck_type_id=@truck_type_id
                                    AND a.active=1
                                    ORDER BY a.truck_no ASC";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("truck_type_id", typeId);
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        Trucks.Add(new Truck
                        {
                            TruckNo = item["truck_no"].ToString(),
                            TruckType = item["truck_type_desc"].ToString(),
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
        public static DataTable GetAllTrucks(string keyword)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT a.truck_no,a.driver,b.truck_type_desc as truck_type,
                            a.active,a.create_at,a.create_by,a.modified_at,a.modified_by
                            FROM truck a,truck_type b
                            WHERE a.truck_type_id =b.truck_type_id
                            AND a.driver like @driver
                            AND a.active=1
                            ORDER BY a.truck_no ASC";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("driver", string.Format("%{0}%", keyword));
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
                    var sql = @"SELECT a.truck_no,a.driver,a.truck_type_id,a.active,a.create_at,a.create_by,a.modified_at,a.modified_by,
                                        b.truck_type_desc
                                    FROM truck a,truck_type b
                                    WHERE a.truck_type_id =b.truck_type_id
                                    AND truck_no =@truck_no";

                    var cmd = new MySqlCommand(sql, conn);
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
                            TruckTypeId = ds.Tables[0].Rows[0]["truck_type_id"].ToString().ToInt16(),
                            TruckType = ds.Tables[0].Rows[0]["truck_type_desc"].ToString(),
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
                                truck_type_id,
                                active,
                                create_by )
                                VALUES (@truck_no,
                                @driver,
                                @truck_type_id,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("truck_no", Truck.TruckNo);
                    cmd.Parameters.AddWithValue("driver", Truck.Driver);
                    cmd.Parameters.AddWithValue("truck_type_id", Truck.TruckTypeId);
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
                                truck_type_id=@truck_type_id,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE truck_no=@truck_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("truck_no", Truck.TruckNo);
                    cmd.Parameters.AddWithValue("driver", Truck.Driver);
                    cmd.Parameters.AddWithValue("truck_type_id", Truck.TruckTypeId);
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
