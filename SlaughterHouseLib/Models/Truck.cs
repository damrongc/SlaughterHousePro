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
        public Int32 TruckId { get; set; }
        public string TruckNo { get; set; }
        public string Driver { get; set; }
        public TruckType TruckType { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public static class TruckController
    {
        public static List<Truck> GetAllTrucks(int typeId)
        {
            try
            {
                List<Truck> Trucks = new List<Truck>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT  a.truck_id, a.truck_no,a.driver, b.truck_type_id, b.truck_type_desc
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
                            TruckId = Convert.ToInt32(item["truck_id"]),
                            TruckNo = item["truck_no"].ToString(),
                            TruckType = new TruckType
                            {
                                TruckTypeId = Convert.ToInt32(item["truck_type_id"]),
                                TruckTypeDesc = item["truck_type_desc"].ToString(),
                            },
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

        public static List<Truck> GetAllTrucks()
        {
            try
            {
                List<Truck> Trucks = new List<Truck>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT t.truck_id, t.truck_no, t.driver,   ");
                    sb.Append("  t.truck_type_id, tt.truck_type_desc,  ");
                    sb.Append("  t.active, t.create_at, t.create_by,   ");
                    sb.Append("  t.modified_at, t.modified_by   ");
                    sb.Append(" FROM truck t, truck_type tt ");
                    sb.Append(" WHERE t.active=1 ");
                    sb.Append(" and t.truck_type_id = tt.truck_type_id ");

                    sb.Append(" ORDER BY truck_no asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        Trucks.Add(new Truck
                        {
                            TruckId = Convert.ToInt32(item["truck_id"]),
                            TruckNo = item["truck_no"].ToString(),
                            Driver = item["driver"].ToString(),
                            TruckType = new TruckType
                            {
                                TruckTypeId = Convert.ToInt32(item["truck_type_id"]),
                                TruckTypeDesc = item["truck_type_desc"].ToString(),
                            }
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
                    var sb = new StringBuilder();
                    sb.Append("SELECT t.truck_id, t.truck_no, t.driver,   ");
                    sb.Append("  t.truck_type_id, tt.truck_type_desc,  ");
                    sb.Append("  t.active, t.create_at, t.create_by,   ");
                    sb.Append("  t.modified_at, t.modified_by   ");
                    sb.Append(" FROM truck t, truck_type tt ");
                    sb.Append(" WHERE 1=1 ");
                    sb.Append(" and t.truck_type_id = tt.truck_type_id ");

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" and ( t.truck_no like @truck_no ");
                        sb.Append("  or t.driver like @driver )");

                    }

                    sb.Append(" order by t.driver asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("truck_no", string.Format("%{0}%", keyword));
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
                    sb.Append(" select t.truck_no from transport tp, truck t ");
                    sb.Append(" where tp.ref_document_no = @ref_document_no");
                    sb.Append(" and tp.truck_id = t.truck_id");

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
        public static Truck GetTruck(Int32 truckId)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();

                    sb.Append("SELECT t.truck_id, t.truck_no, t.driver, ");
                    sb.Append("  t.truck_type_id, tt.truck_type_desc, ");
                    sb.Append("  t.active, t.create_at, t.create_by, ");
                    sb.Append("  t.modified_at, t.modified_by ");
                    sb.Append(" FROM truck t, truck_type tt ");
                    sb.Append(" WHERE t.truck_type_id = tt.truck_type_id ");
                    sb.Append(" and truck_id = @truck_id");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("truck_id", truckId);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var farm = new Truck();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Truck
                        {
                            TruckId = Convert.ToInt32(ds.Tables[0].Rows[0]["truck_id"]),
                            TruckNo = ds.Tables[0].Rows[0]["truck_no"].ToString(),
                            Driver = ds.Tables[0].Rows[0]["driver"].ToString(),
                            TruckType = new TruckType
                            {
                                TruckTypeId = Convert.ToInt32(ds.Tables[0].Rows[0]["truck_type_id"]),
                                TruckTypeDesc = ds.Tables[0].Rows[0]["truck_type_desc"].ToString(),
                            },
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
                    cmd.Parameters.AddWithValue("truck_type_id", Truck.TruckType.TruckTypeId);
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
                                SET truck_no=@truck_no,
                                driver=@driver,
                                truck_type_id=@truck_type_id,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE truck_id=@truck_id";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("truck_id", Truck.TruckId);
                    cmd.Parameters.AddWithValue("truck_no", Truck.TruckNo);
                    cmd.Parameters.AddWithValue("driver", Truck.Driver);
                    cmd.Parameters.AddWithValue("truck_type_id", Truck.TruckType.TruckTypeId);
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
