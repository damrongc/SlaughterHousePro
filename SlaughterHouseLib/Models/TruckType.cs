using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SlaughterHouseLib.Models
{
    public class TruckType
    {
        public Int32 TruckTypeId { get; set; }
        public string TruckTypeDesc { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public static class TruckTypeController
    {
        public static List<TruckType> GetAllTruckType()
        {
            try
            {
                List<TruckType> Trucks = new List<TruckType>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM truck_type WHERE active=1");
                    sb.Append(" ORDER BY truck_type_id asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        Trucks.Add(new TruckType
                        {
                            TruckTypeId = Convert.ToInt32(item["truck_type_id"]),
                            TruckTypeDesc =  item["truck_type_desc"].ToString(),
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
        public static DataTable GetAllTruckType(string keyword)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from truck_type");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" where truck_type_desc like @truck_type_desc");

                    }

                    sb.Append(" order by truck_type_id asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("truck_type_desc", string.Format("%{0}%", keyword));
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

        public static TruckType GetTruckType(string truckTypeId)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from truck_type");
                    sb.Append(" where truck_type_id = @truck_type_id");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("truck_type_id", truckTypeId);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var truckType = new TruckType();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new TruckType
                        {

                            TruckTypeId= Convert.ToInt32(ds.Tables[0].Rows[0]["truck_type_id"]) ,
                            TruckTypeDesc = ds.Tables[0].Rows[0]["truck_type_desc"].ToString(),
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
        public static bool Insert(TruckType truckType)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO slaughterhouse.truck_type
                                (  
                                truck_type_desc,
                                active, 
                                create_by )
                                VALUES ( 
                                @truck_type_desc,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("truck_type_id", truckType.TruckTypeId);
                    cmd.Parameters.AddWithValue("truck_type_desc", truckType.TruckTypeDesc);
                    cmd.Parameters.AddWithValue("active", truckType.Active);
                    cmd.Parameters.AddWithValue("create_by", truckType.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Update(TruckType truckType)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE truck_type
                                SET truck_type_desc=@truck_type_desc,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE truck_type_id=@truck_type_id";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("truck_type_id", truckType.TruckTypeId);
                    cmd.Parameters.AddWithValue("truck_type_desc", truckType.TruckTypeDesc);
                    cmd.Parameters.AddWithValue("active", truckType.Active);
                    cmd.Parameters.AddWithValue("modified_by", truckType.ModifiedBy);
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
