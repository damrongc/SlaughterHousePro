using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public Unit UnitOfQty { get; set; }
        public Unit UnitOfWgh { get; set; }

    }

    public static class ProductController
    {
        public static object GetAllProducts(string keyword)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select a.product_code,a.product_name");
                    sb.Append(" ,b.product_group_name");
                    sb.Append(" ,unit_of_qty ,(select unit_name from unit_of_measurement where unit_code=a.unit_of_qty) as unit_name_of_qty");
                    sb.Append(" ,unit_of_wgh ,(select unit_name from unit_of_measurement where unit_code=a.unit_of_wgh) as unit_name_of_wgh");
                    sb.Append(" ,a.active,a.create_at, a.create_by, a.modified_at, a.modified_by");
                    sb.Append(" from product a,product_group b");
                    sb.Append(" where a.product_group_code=b.product_group_code");

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" and (product_code like @product_code");
                        sb.Append(" or product_name like @product_name)");

                    }
                    sb.Append(" order by product_code asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("product_code", string.Format("%{0}%", keyword));
                        cmd.Parameters.AddWithValue("product_name", string.Format("%{0}%", keyword));
                    }


                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);
                   

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    ProductCode = p.Field<string>("product_code"),
                                    ProductName = p.Field<string>("product_name"),
                                    ProductGroupName = p.Field<string>("product_group_name"),
                                    UnitQtyName = p.Field<string>("unit_name_of_qty"),
                                    UnitWghName = p.Field<string>("unit_name_of_wgh"),
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
        public static List<Product> GetAllProducts()
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT * FROM product WHERE active=1");
                    sb.Append(" ORDER BY product_code ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var products = new List<Product>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        products.Add(new Product
                        {
                            ProductCode = row["product_code"].ToString(),
                            ProductName = row["product_name"].ToString()
                        });
                    }

                    return products;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Product GetProduct(string product_code)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select * from product");
                    sb.Append(" where product_code = @product_code");

                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("product_code", product_code);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var farm = new Product();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Product
                        {

                            ProductCode = ds.Tables[0].Rows[0]["product_code"].ToString(),
                            ProductName = ds.Tables[0].Rows[0]["product_name"].ToString(),

                            ProductGroup = new ProductGroup
                            {
                                ProductGroupCode = (int)ds.Tables[0].Rows[0]["product_group_code"],
                                ProductGroupName = ds.Tables[0].Rows[0]["product_group_code"].ToString(),
                            },
                            UnitOfQty = new Unit
                            {
                                UnitCode = (int)ds.Tables[0].Rows[0]["unit_of_qty"],
                                //UnitName = ds.Tables[0].Rows[0]["unit_name"].ToString(),
                            },
                            UnitOfWgh = new Unit
                            {
                                UnitCode = (int)ds.Tables[0].Rows[0]["unit_of_wgh"],
                                //UnitName = ds.Tables[0].Rows[0]["unit_name"].ToString(),
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
        public static bool Insert(Product product)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"INSERT INTO product
                                (product_code,
                                product_name,
                                product_group_code,
                                unit_of_qty,
                                unit_of_wgh,
                                active,
                                create_by)
                                VALUES(@product_code,
                                @product_name,
                                @product_group_code,
                                @unit_of_qty,
                                @unit_of_wgh,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", product.ProductCode);
                    cmd.Parameters.AddWithValue("product_name", product.ProductName);
                    cmd.Parameters.AddWithValue("product_group_code", product.ProductGroup.ProductGroupCode);
                    cmd.Parameters.AddWithValue("unit_of_qty", product.UnitOfQty.UnitCode);
                    cmd.Parameters.AddWithValue("unit_of_wgh", product.UnitOfWgh.UnitCode);
                    cmd.Parameters.AddWithValue("active", product.Active);
                    cmd.Parameters.AddWithValue("create_by", product.CreateBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Update(Product product)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE product
                                SET product_name=@product_name,
                                product_group_code=@product_group_code,
                                unit_of_qty=@unit_of_qty,
                                unit_of_wgh=@unit_of_wgh,
                                active=@active,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE product_code=@product_code";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", product.ProductCode);
                    cmd.Parameters.AddWithValue("product_name", product.ProductName);
                    cmd.Parameters.AddWithValue("product_group_code", product.ProductGroup.ProductGroupCode);
                    cmd.Parameters.AddWithValue("unit_of_qty", product.UnitOfQty.UnitCode);
                    cmd.Parameters.AddWithValue("unit_of_wgh", product.UnitOfWgh.UnitCode);
                    cmd.Parameters.AddWithValue("active", product.Active);
                    cmd.Parameters.AddWithValue("modified_by", product.ModifiedBy);
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
