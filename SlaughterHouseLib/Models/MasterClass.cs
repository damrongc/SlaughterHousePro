using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SlaughterHouseLib.Models
{
    public class MasterClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public bool DefaultFlag { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }


    }

    public static class MasterClassController
    {
        public static List<MasterClass> GetAllMasterClass()
        {
            try
            {
                List<MasterClass> masterClass = new List<MasterClass>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM master_class WHERE active=1 and class_id > 1 ");
                    sb.Append(" ORDER BY class_id asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        masterClass.Add(new MasterClass
                        {
                            ClassId = (int)item["class_id"],
                            ClassName = item["class_name"].ToString(),
                            DefaultFlag = (bool)item["default_flag"],
                        });
                    }


                    return masterClass;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static object GetAllMasterClass(string keyword)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from master_class");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" where class_name like @class_name");

                    }

                    sb.Append(" order by class_id asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("class_name", string.Format("%{0}%", keyword));
                    }


                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    ClassId = p.Field<int>("class_id"),
                                    ClassName = p.Field<string>("class_name"),
                                    DefaultFlag = p.Field<bool>("default_flag"),
                                    Active = p.Field<bool>("active"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                    CreateBy = p.Field<string>("create_by"),
                                    ModifiedAt = p.Field<DateTime?>("modified_at") != null ? p.Field<DateTime?>("modified_at") : null,
                                    ModifiedBy = p.Field<string>("modified_by") != "" ? p.Field<string>("modified_by") : "",
                                }).ToList();

                    return coll;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static MasterClass GetMasterClass(int class_id)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from master_class");
                    sb.Append(" where class_id = @class_id");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("class_id", class_id);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var masterClass = new MasterClass();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new MasterClass
                        {

                            ClassId = (int)ds.Tables[0].Rows[0]["class_id"],
                            ClassName = ds.Tables[0].Rows[0]["class_name"].ToString(),
                            DefaultFlag = (bool)ds.Tables[0].Rows[0]["default_flag"],
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
        public static bool Insert(MasterClass masterClass)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO master_class
                                (class_id,
                                class_name,
                                default_flag,
                                active,
                                create_by)
                                VALUES(@class_id,
                                @class_name,
                                @default_flag,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("class_id", masterClass.ClassId);
                    cmd.Parameters.AddWithValue("class_name", masterClass.ClassName);
                    cmd.Parameters.AddWithValue("default_flag", masterClass.DefaultFlag);
                    cmd.Parameters.AddWithValue("active", masterClass.Active);
                    cmd.Parameters.AddWithValue("create_by", masterClass.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool Update(MasterClass masterClass)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE master_class
                                SET class_name=@class_name,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE class_id=@class_id";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("class_id", masterClass.ClassId);
                    cmd.Parameters.AddWithValue("class_name", masterClass.ClassName);
                    cmd.Parameters.AddWithValue("active", masterClass.Active);
                    cmd.Parameters.AddWithValue("modified_by", masterClass.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int GetMasterClassDefaultFlag()
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select class_id from master_class");
                    sb.Append(" where default_flag = 1 order by class_id limit 1 ");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var masterClass = new MasterClass();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return Convert.ToInt32(ds.Tables[0].Rows[0]["class_id"]);
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
