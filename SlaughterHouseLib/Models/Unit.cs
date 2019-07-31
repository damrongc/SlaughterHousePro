using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class Unit
    {
        public int UnitCode { get; set; }
        public string UnitName { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

    }

    public static class UnitController
    {
        public static object GetAllUnits(string keyword)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM unit_of_measurement");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" WHERE Unit_code LIKE @Unit_code");
                        sb.Append(" OR Unit_name LIKE @Unit_name");
                    }

                    sb.Append(" ORDER BY Unit_code asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("Unit_code", string.Format("%{0}%", keyword));
                        cmd.Parameters.AddWithValue("Unit_name", string.Format("%{0}%", keyword)); 
                    }

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
 
                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    UnitCode = p.Field<Int32>("Unit_code"),
                                    UnitName = p.Field<string>("Unit_name"),
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
        public static List<Unit> GetAllUnits()
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM unit_of_measurement WHERE active=1");
                    sb.Append(" ORDER BY Unit_code ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var Units = new List<Unit>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Units.Add(new Unit
                        {
                            UnitCode = Convert.ToInt32(row["Unit_code"]),
                            UnitName = row["Unit_name"].ToString()
                        });
                    }

                    return Units;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Unit GetUnit(string Unit_code)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from unit_of_measurement");
                    sb.Append(" where Unit_code = @Unit_code");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("Unit_code", Unit_code);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var Unit = new Unit();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Unit
                        {
                            UnitCode = Convert.ToInt32(ds.Tables[0].Rows[0]["Unit_code"]),
                            UnitName = ds.Tables[0].Rows[0]["Unit_name"].ToString(),
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
        public static bool Insert(Unit Unit)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO unit_of_measurement
                                (
                                Unit_name, 
                                active,
                                create_by)
                                VALUES(
                                @Unit_name, 
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("Unit_code", Unit.UnitCode);
                    cmd.Parameters.AddWithValue("Unit_name", Unit.UnitName); 
                    cmd.Parameters.AddWithValue("active", Unit.Active);
                    cmd.Parameters.AddWithValue("create_by", Unit.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool Update(Unit Unit)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE unit_of_measurement
                                SET Unit_name=@Unit_name, 
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE Unit_code=@Unit_code";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("Unit_code", Unit.UnitCode);
                    cmd.Parameters.AddWithValue("Unit_name", Unit.UnitName); 
                    cmd.Parameters.AddWithValue("active", Unit.Active);
                    cmd.Parameters.AddWithValue("modified_by", Unit.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Unit GetUnitNameOfIssue(string productCode)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select u.unit_code, u.unit_name
                                from product p, unit_of_measurement u
                                where p.product_code = @product_code
                                and case when p.issue_unit_method = 'Q' then p.unit_of_qty else p.unit_of_wgh end = u.unit_code";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var Unit = new Unit();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Unit
                        {
                            UnitCode = Convert.ToInt32(ds.Tables[0].Rows[0]["Unit_code"]),
                            UnitName = ds.Tables[0].Rows[0]["Unit_name"].ToString()
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

        public static Unit GetUnitNameOfSale(string productCode)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select u.unit_code, u.unit_name
                                from product p, unit_of_measurement u
                                where p.product_code = @product_code
                                and case when p.sale_unit_method = 'Q' then p.unit_of_qty else p.unit_of_wgh end = u.unit_code";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var Unit = new Unit();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Unit
                        {
                            UnitCode = Convert.ToInt32(ds.Tables[0].Rows[0]["Unit_code"]),
                            UnitName = ds.Tables[0].Rows[0]["Unit_name"].ToString()
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

    }
}
