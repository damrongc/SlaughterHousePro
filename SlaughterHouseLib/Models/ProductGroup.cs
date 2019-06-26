using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SlaughterHouseLib.Models
{
    public class ProductGroup
    {
        public int ProductGroupCode { get; set; }
        public string ProductGroupName { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

    }

    public static class ProductGroupController
    {

        public static object GetAllProudctGroups(string keyword)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from product_group");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" where product_group_name like @product_group_name");

                    }

                    sb.Append(" order by product_group_code asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("product_group_name", string.Format("%{0}%", keyword));
                    }


                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    ProductGroupCode = p.Field<int>("product_group_code"),
                                    ProductGroupName = p.Field<string>("product_group_name"),
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
        public static List<ProductGroup> GetAllProudctGroups()
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM product_group WHERE active=1");
                    sb.Append(" ORDER BY product_group_code ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var productgroups = new List<ProductGroup>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        productgroups.Add(new ProductGroup
                        {
                            ProductGroupCode = Convert.ToInt32(row["product_group_code"]),
                            ProductGroupName = row["product_group_name"].ToString()

                        });
                    }

                    return productgroups;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static ProductGroup GetProductGroup(string product_group_code)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from product_group");
                    sb.Append(" where product_group_code = @product_group_code");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("product_group_code", product_group_code);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var farm = new ProductGroup();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new ProductGroup
                        {
                            ProductGroupCode = (int)ds.Tables[0].Rows[0]["product_group_code"],
                            ProductGroupName = ds.Tables[0].Rows[0]["product_group_name"].ToString(),
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
        public static bool Insert(ProductGroup productGroup)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO product_group
                                (product_group_code,
                                product_group_name,
                                active,
                                create_by)
                                VALUES(@product_group_code,
                                @product_group_name,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_group_code", productGroup.ProductGroupCode);
                    cmd.Parameters.AddWithValue("product_group_name", productGroup.ProductGroupName);
                    cmd.Parameters.AddWithValue("active", productGroup.Active);
                    cmd.Parameters.AddWithValue("create_by", productGroup.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Update(ProductGroup productGroup)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE product_group
                                SET product_group_name=@product_group_name,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE product_group_code=@product_group_code";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_group_code", productGroup.ProductGroupCode);
                    cmd.Parameters.AddWithValue("product_group_name", productGroup.ProductGroupName);
                    cmd.Parameters.AddWithValue("active", productGroup.Active);
                    cmd.Parameters.AddWithValue("modified_by", productGroup.ModifiedBy);
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
