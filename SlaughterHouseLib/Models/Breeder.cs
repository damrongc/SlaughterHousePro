using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SlaughterHouseLib.Models
{
    public class Breeder
    {
        public int BreederCode { get; set; }
        public string BreederName { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }


    }

    public static class BreederController
    {
        public static List<Breeder> GetAllBreeders()
        {
            try
            {
                List<Breeder> breeders = new List<Breeder>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM breeder WHERE active=1");
                    sb.Append(" ORDER BY breeder_code asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        breeders.Add(new Breeder
                        {
                            BreederCode = (int)item["breeder_code"],
                            BreederName = item["breeder_name"].ToString(),
                        });
                    }

                    //var coll = (from p in ds.Tables[0].AsEnumerable()
                    //            select new
                    //            {
                    //                BreederCode = p.Field<int>("breeder_code"),
                    //                BreederName = p.Field<string>("breeder_name"),
                    //                Active = p.Field<bool>("active"),
                    //                CreateAt = p.Field<DateTime>("create_at"),
                    //            }).ToList();

                    return breeders;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static object GetAllBreeders(string keyword)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from breeder");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" where breeder_name like @breeder_name");

                    }

                    sb.Append(" order by breeder_code asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("breeder_name", string.Format("%{0}%", keyword));
                    }


                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    BreederCode = p.Field<int>("breeder_code"),
                                    BreederName = p.Field<string>("breeder_name"),
                                    Active = p.Field<bool>("active"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                }).ToList();

                    return coll;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Breeder GetBreeder(string breeder_code)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from breeder");
                    sb.Append(" where breeder_code = @breeder_code");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("breeder_code", breeder_code);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var farm = new Breeder();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Breeder
                        {

                            BreederCode = (int)ds.Tables[0].Rows[0]["breeder_code"],
                            BreederName = ds.Tables[0].Rows[0]["breeder_name"].ToString(),
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
        public static bool Insert(Breeder breeder)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO breeder
                                (breeder_code,
                                breeder_name,
                                active,
                                create_by)
                                VALUES(@breeder_code,
                                @breeder_name,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("breeder_code", breeder.BreederCode);
                    cmd.Parameters.AddWithValue("breeder_name", breeder.BreederName);
                    cmd.Parameters.AddWithValue("active", breeder.Active);
                    cmd.Parameters.AddWithValue("create_by", breeder.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Update(Breeder breeder)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE breeder
                                SET breeder_name=@breeder_name,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE breeder_code=@breeder_code";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("breeder_code", breeder.BreederCode);
                    cmd.Parameters.AddWithValue("breeder_name", breeder.BreederName);
                    cmd.Parameters.AddWithValue("active", breeder.Active);
                    cmd.Parameters.AddWithValue("modified_by", breeder.ModifiedBy);
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
