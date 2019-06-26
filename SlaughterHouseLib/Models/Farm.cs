using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class Farm
    {
        public string FarmCode { get; set; }
        public string FarmName { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

    }

    public static class FarmController
    {
        public static object GetAllFarms(string keyword)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM farm");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" WHERE farm_code LIKE @farm_code");
                        sb.Append(" OR farm_name LIKE @farm_name");
                        sb.Append(" OR address LIKE @address");
                    }

                    sb.Append(" ORDER BY farm_code asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("farm_code", string.Format("%{0}%", keyword));
                        cmd.Parameters.AddWithValue("farm_name", string.Format("%{0}%", keyword));
                        cmd.Parameters.AddWithValue("address", string.Format("%{0}%", keyword));
                    }


                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);



                    //var farms = new List<Farm>();
                    //foreach (DataRow row in ds.Tables[0].Rows)
                    //{
                    //    farms.Add(new Farm
                    //    {
                    //        FarmCode = row["farm_code"].ToString(),
                    //        FarmName = row["farm_name"].ToString(),
                    //        Address = row["address"].ToString(),
                    //        Active = (bool)row["active"],
                    //        CreateAt = (DateTime)row["create_at"],
                    //    });
                    //}
                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    FarmCode = p.Field<string>("farm_code"),
                                    FarmName = p.Field<string>("farm_name"),
                                    Address = p.Field<string>("address"),
                                    Active = p.Field<bool>("active"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                    CreateBy = p.Field<string>("create_by"),
                                    ModifiedAt = p.Field<DateTime?>("modified_at") == null ? null : p.Field<DateTime?>("modified_at"),
                                    ModifiedBy = p.Field<string>("modified_by") != "" ? p.Field<string>("modified_by") : "",
                                }).ToList();

                    //GetData(ds.Tables[0]);
                    return coll;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Farm> GetAllFarms()
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM farm WHERE active=1");
                    sb.Append(" ORDER BY farm_code ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);



                    var farms = new List<Farm>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        farms.Add(new Farm
                        {
                            FarmCode = row["farm_code"].ToString(),
                            FarmName = row["farm_name"].ToString()

                        });
                    }

                    return farms;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Farm GetFarm(string farm_code)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from farm");
                    sb.Append(" where farm_code = @farm_code");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("farm_code", farm_code);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var farm = new Farm();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Farm
                        {
                            FarmCode = ds.Tables[0].Rows[0]["farm_code"].ToString(),
                            FarmName = ds.Tables[0].Rows[0]["farm_name"].ToString(),
                            Address = ds.Tables[0].Rows[0]["address"].ToString(),
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
        public static bool Insert(Farm farm)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO farm
                                (farm_code,
                                farm_name,
                                address,
                                active,
                                create_by)
                                VALUES(@farm_code,
                                @farm_name,
                                @address,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("farm_code", farm.FarmCode);
                    cmd.Parameters.AddWithValue("farm_name", farm.FarmName);
                    cmd.Parameters.AddWithValue("address", farm.Address);
                    cmd.Parameters.AddWithValue("active", farm.Active);
                    cmd.Parameters.AddWithValue("create_by", farm.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Update(Farm farm)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE farm
                                SET farm_name=@farm_name,
                                address=@address,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE farm_code=@farm_code";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("farm_code", farm.FarmCode);
                    cmd.Parameters.AddWithValue("farm_name", farm.FarmName);
                    cmd.Parameters.AddWithValue("address", farm.Address);
                    cmd.Parameters.AddWithValue("active", farm.Active);
                    cmd.Parameters.AddWithValue("modified_by", farm.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public List<dynamic> GetData(DataTable dt)
        //{
        //    List<dynamic> coll = new List<dynamic>();

        //    foreach (var item in dt.AsEnumerable())
        //    {
        //        IDictionary<string, object> dn = new ExpandoObject();

        //        foreach (var column in dt.Columns.Cast<DataColumn>()) dn[column.ColumnName] = item[column];

        //        coll.Add(dn);
        //    }

        //    return coll;
        //}




    }
}
