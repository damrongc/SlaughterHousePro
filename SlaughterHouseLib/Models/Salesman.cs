using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace SlaughterHouseLib.Models
{
    public class Salesman
    {
        public int SalesmanCode { get; set; }
        public string SalesmanName { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public static class SalesmanController
    {
        public static List<Salesman> GetAllSalesmans()
        {
            try
            {
                List<Salesman> Salesmans = new List<Salesman>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM salesman WHERE active=1");
                    sb.Append(" ORDER BY salesman_code asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        Salesmans.Add(new Salesman
                        {
                            SalesmanCode = (int)item["salesman_code"],
                            SalesmanName = item["salesman_name"].ToString(),
                        });
                    }

                    return Salesmans;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataTable GetAllSalesmans(string keyword)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    //var sql = @"SELECT
                    //    a.salesman_code,
                    //    a.salesman_name,
                    //    a.active,
                    //    a.create_at,
                    //    a.create_by,
                    //    a.modified_at,
                    //    a.modified_by,
                    //    b.customer_name
                    //FROM
                    //    salesman a,
                    //    customer b
                    //WHERE
                    //    a.salesman_code = b.salesman_code";
                    sb.Append("SELECT * from salesman");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" WHERE salesman_name like @salesman_name");

                    }

                    sb.Append(" order by salesman_code asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("salesman_name", string.Format("%{0}%", keyword));
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
        public static Salesman GetSalesman(int id)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from salesman");
                    sb.Append(" where salesman_code = @salesman_code");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("salesman_code", id);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    //var farm = new Salesman();
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return null;
                    }
                    return new Salesman
                    {
                        SalesmanCode = (int)ds.Tables[0].Rows[0]["salesman_code"],
                        SalesmanName = ds.Tables[0].Rows[0]["salesman_name"].ToString(),
                        Active = (bool)ds.Tables[0].Rows[0]["active"],
                        CreateAt = (DateTime)ds.Tables[0].Rows[0]["create_at"],
                    };

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Insert(Salesman Salesman)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO salesman
                                (salesman_code,
                                salesman_name,
                                active,
                                create_by)
                                VALUES(@salesman_code,
                                @salesman_name,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("salesman_code", Salesman.SalesmanCode);
                    cmd.Parameters.AddWithValue("salesman_name", Salesman.SalesmanName);
                    cmd.Parameters.AddWithValue("active", Salesman.Active);
                    cmd.Parameters.AddWithValue("create_by", Salesman.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Update(Salesman Salesman)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE salesman
                                SET salesman_name=@salesman_name,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE salesman_code=@salesman_code";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("salesman_code", Salesman.SalesmanCode);
                    cmd.Parameters.AddWithValue("salesman_name", Salesman.SalesmanName);
                    cmd.Parameters.AddWithValue("active", Salesman.Active);
                    cmd.Parameters.AddWithValue("modified_by", Salesman.ModifiedBy);
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
