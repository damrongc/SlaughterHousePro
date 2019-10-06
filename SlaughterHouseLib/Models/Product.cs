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
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal StdYield { get; set; }
        public decimal PackingSize { get; set; }
        public string SaleUnitMethod { get; set; }
        public string IssueUnitMethod { get; set; }
    }




    public static class ProductController
    {
        public static DataTable GetAllProducts(string productGroup, string keyword)
        {
            try
            {
                //sale_unit_method   issue_unit_method
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("select a.product_code,a.product_name");
                    sb.Append(" ,b.product_group_name");
                    sb.Append(" ,unit_of_qty ,(select unit_name from unit_of_measurement where unit_code=a.unit_of_qty) as unit_name_qty");
                    sb.Append(" ,unit_of_wgh ,(select unit_name from unit_of_measurement where unit_code=a.unit_of_wgh) as unit_name_wgh");
                    sb.Append(" ,min_weight, max_weight, std_yield ");
                    sb.Append(" ,sale_unit_method, issue_unit_method ");
                    sb.Append(" ,a.packing_size, a.active,  a.create_at, a.create_by, a.modified_at, a.modified_by");
                    sb.Append(" from product a,product_group b");
                    sb.Append(" where a.product_group_code=b.product_group_code and a.product_code <> 'NA' ");

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        sb.Append(" and (product_code like @product_code");
                        sb.Append(" or product_name like @product_name)");
                    }
                    if (String.IsNullOrEmpty(productGroup) == false)
                    {

                        sb.Append(" and a.product_group_code like @product_group_code ");
                    }
                    sb.Append(" order by product_name asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("product_code", string.Format("%{0}%", keyword));
                        cmd.Parameters.AddWithValue("product_name", string.Format("%{0}%", keyword));
                    }
                    if (String.IsNullOrEmpty(productGroup) == false)
                    {
                        productGroup = (productGroup == "0") ? "%" : productGroup;
                        cmd.Parameters.AddWithValue("product_group_code", productGroup);
                    }

                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);


                    //var coll = (from p in ds.Tables[0].AsEnumerable()
                    //            select new
                    //            {
                    //                ProductCode = p.Field<string>("product_code"),
                    //                ProductName = p.Field<string>("product_name"),
                    //                ProductGroupName = p.Field<string>("product_group_name"),
                    //                UnitQtyName = p.Field<string>("unit_name_of_qty"),
                    //                UnitWghName = p.Field<string>("unit_name_of_wgh"),
                    //                MinWeight = p.Field<decimal>("min_weight"),
                    //                MaxWeight = p.Field<decimal>("max_weight"),
                    //                StdYield = p.Field<decimal>("std_yield"),
                    //                SaleUnitMethod = p.Field<string>("sale_unit_method"),
                    //                IssueUnitMethod = p.Field<string>("issue_unit_method"),
                    //                PackingSize = p.Field<decimal>("packing_size"),
                    //                Active = p.Field<bool>("active"),
                    //                CreateAt = p.Field<DateTime>("create_at"),
                    //                CreateBy = p.Field<string>("create_by"),
                    //                ModifiedAt = p.Field<DateTime?>("modified_at") != null ? p.Field<DateTime?>("modified_at") : null,
                    //                ModifiedBy = p.Field<string>("modified_by") != "" ? p.Field<string>("modified_by") : "",
                    //            }).ToList();
                    return ds.Tables[0];
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
                    sb.Append("SELECT * FROM product WHERE active=1 and product_code <> 'NA' ");
                    sb.Append(" ORDER BY product_name ASC");
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
        public static DataTable GetProductsForSale(string productGroup, string productCode, string productName)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"
                                    Select distinct 0 as select_col, p.product_code, product_name,
	                                    p.issue_unit_method, 
	                                    p.unit_of_qty as unit_code_qty,            
	                                    uq.unit_name as unit_name_qty,
	                                    p.unit_of_wgh as unit_code_wgh,
	                                    uw.unit_name as unit_name_wgh,
	                                    p.packing_size
                                    From product p,
	                                    (    select distinct pp.start_date, pp.end_date, pp.product_code
                                        from product_price pp
                                        Where  DATE_FORMAT(sysdate(),'%Y-%m-%d')  >= pp.start_date
		                                    and DATE_FORMAT(sysdate(),'%Y-%m-%d')  <= pp.end_date
                                        union
	                                    select distinct cp.start_date, cp.end_date, cp.product_code
                                        from customer_price cp
	                                    Where  DATE_FORMAT(sysdate(),'%Y-%m-%d')  >= cp.start_date
		                                    and DATE_FORMAT(sysdate(),'%Y-%m-%d')  <= cp.end_date) as price,
	                                    unit_of_measurement uq,
	                                    unit_of_measurement uw
                                    where p.product_code = price.product_code
	                                    and DATE_FORMAT(sysdate(),'%Y-%m-%d')  >= price.start_date
	                                    and DATE_FORMAT(sysdate(),'%Y-%m-%d')  <= price.end_date
	                                    and p.active = 1 
	                                    and p.unit_of_qty = uq.unit_code
	                                    and p.unit_of_wgh = uw.unit_code
                              ";
                    if (String.IsNullOrEmpty(productGroup) == false)
                    {
                        productGroup = (productGroup == "0") ? "" : productGroup;
                        sql += $" and p.product_group_code like '%{productGroup}%' ";
                    }
                    if (String.IsNullOrEmpty(productCode) == false)
                    {
                        sql += $" and p.product_code like '%{productCode}%' ";
                    }
                    if (String.IsNullOrEmpty(productName) == false)
                    {
                        sql += $" and p.product_name like '%{productName}%' ";
                    }
                    sql += "  order by p.product_name  ";
                    var cmd = new MySqlCommand(sql, conn);

                    //if (String.IsNullOrEmpty(productCode) == false)
                    //{
                    //    cmd.Parameters.AddWithValue("product_code", productCode);
                    //}
                    //if (String.IsNullOrEmpty(productName) == false)
                    //{
                    //    cmd.Parameters.AddWithValue("product_name", productName);
                    //}

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);


                    //var coll = (from p in ds.Tables[0].AsEnumerable()
                    //            select new
                    //            {
                    //                ProductCode = p.Field<string>("product_code"),
                    //                ProductName = p.Field<string>("product_name"),
                    //            }).ToList();

                    return ds.Tables[0];
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetProductActive(string productGroup, string productCode, string productName, bool mutiSelectFlag = false)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"";
                    if (mutiSelectFlag == true)
                    {
                        sql = @"
                                Select distinct 0 as select_col,  p.product_code, product_name,
                                    p.issue_unit_method,  
                                    p.unit_of_qty as unit_code_qty,            
                                    uq.unit_name as unit_name_qty,
                                    p.unit_of_wgh as unit_code_wgh,
                                    uw.unit_name as unit_name_wgh,
                                    p.packing_size
                                From product p, 
                                    unit_of_measurement uq,
                                    unit_of_measurement uw
                                where p.active = 1 
                                    and p.unit_of_qty = uq.unit_code
                                    and p.unit_of_wgh = uw.unit_code
                                    and p.product_code <> 'NA'
                              ";
                    }
                    else
                    {
                        sql = @"
                                Select distinct  p.product_code, product_name,
                                    p.issue_unit_method, 
                                    p.unit_of_qty as unit_code_qty,            
                                    uq.unit_name as unit_name_qty,
                                    p.unit_of_wgh as unit_code_wgh,
                                    uw.unit_name as unit_name_wgh,
                                    p.packing_size
                                From product p, 
                                    unit_of_measurement uq,
                                    unit_of_measurement uw
                                where p.active = 1 
                                    and p.unit_of_qty = uq.unit_code
                                    and p.unit_of_wgh = uw.unit_code
                                    and p.product_code <> 'NA'
                              ";
                    }
                    if (String.IsNullOrEmpty(productGroup) == false)
                    {
                        productGroup = (productGroup == "0") ? "" : productGroup;
                        sql += $" and p.product_group_code like '%{productGroup}%' ";
                    }
                    if (String.IsNullOrEmpty(productCode) == false)
                    {
                        sql += $" and p.product_code like '%{productCode}%' ";
                    }
                    if (String.IsNullOrEmpty(productName) == false)
                    {
                        sql += $" and p.product_name like '%{productName}%' ";
                    }
                    sql += "  order by p.product_name  ";
                    var cmd = new MySqlCommand(sql, conn);

                    //if (String.IsNullOrEmpty(productCode) == false)
                    //{
                    //    cmd.Parameters.AddWithValue("product_code", productCode);
                    //}
                    //if (String.IsNullOrEmpty(productName) == false)
                    //{
                    //    cmd.Parameters.AddWithValue("product_name", productName);
                    //}

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);


                    //var coll = (from p in ds.Tables[0].AsEnumerable()
                    //            select new
                    //            {
                    //                ProductCode = p.Field<string>("product_code"),
                    //                ProductName = p.Field<string>("product_name"),
                    //            }).ToList();

                    return ds.Tables[0];
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
                            MinWeight = Convert.ToDecimal(ds.Tables[0].Rows[0]["min_weight"]),
                            MaxWeight = Convert.ToDecimal(ds.Tables[0].Rows[0]["max_weight"]),
                            StdYield = Convert.ToDecimal(ds.Tables[0].Rows[0]["std_yield"]),
                            PackingSize = Convert.ToDecimal(ds.Tables[0].Rows[0]["packing_size"]),
                            SaleUnitMethod = ds.Tables[0].Rows[0]["sale_unit_method"].ToString(),
                            IssueUnitMethod = ds.Tables[0].Rows[0]["issue_unit_method"].ToString(),
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
                                min_weight, max_weight, std_yield,
                                sale_unit_method, issue_unit_method,
                                packing_size,
                                active,
                                create_by)
                                VALUES(@product_code,
                                @product_name,
                                @product_group_code,
                                @unit_of_qty,
                                @unit_of_wgh,
                                @min_weight, @max_weight, @std_yield,
                                @sale_unit_method, @issue_unit_method,
                                @packing_size,
                                @active,
                                @create_by)";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", product.ProductCode);
                    cmd.Parameters.AddWithValue("product_name", product.ProductName);
                    cmd.Parameters.AddWithValue("product_group_code", product.ProductGroup.ProductGroupCode);
                    cmd.Parameters.AddWithValue("unit_of_qty", product.UnitOfQty.UnitCode);
                    cmd.Parameters.AddWithValue("unit_of_wgh", product.UnitOfWgh.UnitCode);
                    cmd.Parameters.AddWithValue("min_weight", product.MinWeight);
                    cmd.Parameters.AddWithValue("max_weight", product.MaxWeight);
                    cmd.Parameters.AddWithValue("std_yield", product.StdYield);
                    cmd.Parameters.AddWithValue("sale_unit_method", product.SaleUnitMethod);
                    cmd.Parameters.AddWithValue("issue_unit_method", product.IssueUnitMethod);
                    cmd.Parameters.AddWithValue("packing_size", product.PackingSize);
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
                                min_weight=@min_weight, 
                                max_weight=@max_weight, 
                                std_yield=@std_yield,
                                sale_unit_method = @sale_unit_method, 
                                issue_unit_method = @issue_unit_method,
                                active=@active,
                                packing_size=@packing_size,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE product_code=@product_code";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("product_code", product.ProductCode);
                    cmd.Parameters.AddWithValue("product_name", product.ProductName);
                    cmd.Parameters.AddWithValue("product_group_code", product.ProductGroup.ProductGroupCode);
                    cmd.Parameters.AddWithValue("unit_of_qty", product.UnitOfQty.UnitCode);
                    cmd.Parameters.AddWithValue("unit_of_wgh", product.UnitOfWgh.UnitCode);

                    cmd.Parameters.AddWithValue("min_weight", product.MinWeight);
                    cmd.Parameters.AddWithValue("max_weight", product.MaxWeight);
                    cmd.Parameters.AddWithValue("std_yield", product.StdYield);

                    cmd.Parameters.AddWithValue("sale_unit_method", product.SaleUnitMethod);
                    cmd.Parameters.AddWithValue("issue_unit_method", product.IssueUnitMethod);
                    cmd.Parameters.AddWithValue("packing_size", product.PackingSize);

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
