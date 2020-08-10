using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib
{

    public static class InvoiceController
    {
        public static object GetAllInvoices(DateTime InvoiceDate, string customerCode = "")
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT a.invoice_No, a.invoice_date,");
                    sb.Append(" a.Ref_Document_No, a.customer_code, t.truck_no,");
                    sb.Append(" a.disc_amt, a.Gross_Amt, a.disc_amt_bill,");
                    sb.Append(" a.Vat_Rate, a.Vat_Amt,");
                    sb.Append(" a.Net_Amt, a.invoice_Flag,");
                    sb.Append(" a.comments,");
                    sb.Append(" a.active,");
                    sb.Append(" a.create_at,");
                    sb.Append(" a.create_by,");
                    sb.Append(" b.customer_name,");
                    sb.Append(" a.print_no, a.receipt_no ");
                    sb.Append(" FROM invoice a,customer b, truck t");
                    sb.Append(" WHERE a.customer_code =b.customer_code");
                    sb.Append(" AND a.invoice_date =@invoice_date");
                    sb.Append(" AND t.truck_id = a.truck_id");
                    //sb.Append(" AND a.active = 1");

                    if (!string.IsNullOrEmpty(customerCode))
                        sb.Append(" AND a.customer_code =@customer_code");
                    sb.Append(" Order BY invoice_no ASC");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("invoice_date", InvoiceDate.ToString("yyyy-MM-dd"));

                    if (!string.IsNullOrEmpty(customerCode))
                        cmd.Parameters.AddWithValue("customer_code", customerCode);
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    INVOICE_NO = p.Field<string>("invoice_no"),
                                    INVOICE_DATE = p.Field<DateTime>("invoice_date"),
                                    REF_DOCUMENT_NO = p.Field<string>("Ref_Document_No"),
                                    RECEIPT_NO = p.Field<string>("receipt_no"),
                                    CUSTOMER_NAME = p.Field<string>("customer_name"),
                                    TRUCK_NO = p.Field<string>("truck_no"),
                                    GROSS_AMT = p.Field<decimal>("gross_Amt"),
                                    DISC_AMT = p.Field<decimal>("disc_amt"),
                                    DISC_AMT_BILL = p.Field<decimal>("disc_amt_bill"),
                                    //VatRate = p.Field<decimal>("vat_rate"),
                                    VAT_AMT = p.Field<decimal>("vat_amt"),
                                    NET_AMT = p.Field<decimal>("Net_Amt"),
                                    //InvoiceFlag = p.Field<int>("invoice_flag"),
                                    //Comments = p.Field<string>("comments"),
                                    PRINT_NO = p.Field<int>("print_no"),
                                    ACTIVE = p.Field<bool>("active"),
                                    CREATE_AT = p.Field<DateTime>("create_at"),
                                }).ToList();

                    return coll;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Invoice GetInvoice(string invoiceNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT invoice_no,
								invoice_date,
								ref_document_no,
                                receipt_no,
								customer_code,
                                truck_id,
								gross_amt,
								disc_amt,
								disc_amt_bill,
								vat_rate,
								vat_amt,
								net_amt,
								invoice_flag,
								comments,
                                print_no,
								active,
								create_at
								FROM invoice
								WHERE invoice_no =@invoice_no ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("invoice_no", invoiceNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Invoice
                        {

                            InvoiceNo = (string)ds.Tables[0].Rows[0]["invoice_no"],
                            InvoiceDate = (DateTime)ds.Tables[0].Rows[0]["invoice_date"],
                            RefDocumentNo = (string)ds.Tables[0].Rows[0]["ref_document_no"],
                            ReceiptNo = ds.Tables[0].Rows[0]["receipt_no"] == DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["receipt_no"],
                            Customer = new Customer
                            {
                                CustomerCode = (string)ds.Tables[0].Rows[0]["customer_code"]
                            },
                            Truck = new Truck
                            {
                                TruckId = Convert.ToInt32(ds.Tables[0].Rows[0]["truck_id"])
                            },
                            GrossAmt = (decimal)ds.Tables[0].Rows[0]["gross_amt"],
                            DiscAmt = (decimal)ds.Tables[0].Rows[0]["disc_amt"],
                            DiscAmtBill = (decimal)ds.Tables[0].Rows[0]["disc_amt_bill"],
                            VatRate = (decimal)ds.Tables[0].Rows[0]["vat_rate"],
                            VatAmt = (decimal)ds.Tables[0].Rows[0]["vat_amt"],
                            NetAmt = (decimal)ds.Tables[0].Rows[0]["net_amt"],
                            Comments = (string)ds.Tables[0].Rows[0]["comments"],
                            PrintNo = (int)ds.Tables[0].Rows[0]["print_no"],
                            InvoiceFlag = (int)ds.Tables[0].Rows[0]["invoice_flag"],
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
        public static bool Insert(Invoice Invoice)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {

                    Invoice.InvoiceNo = DocumentGenerate.GetDocumentRunningFormat("IV", Invoice.InvoiceDate);
                    Invoice.ReceiptNo = DocumentGenerate.GetDocumentRunningFormat("RC", Invoice.InvoiceDate);
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = @"INSERT
								INTO invoice(
									invoice_no, invoice_date, ref_document_no, receipt_no,
									customer_code, truck_id, gross_amt, disc_amt, disc_amt_bill,
									vat_rate, vat_amt, net_amt,  
									invoice_flag, comments, active,
									create_by
								)
								VALUES( @invoice_no, @invoice_date, @ref_document_no, @receipt_no,
									@customer_code, @truck_id, @gross_amt, @disc_amt, @disc_amt_bill,
									@vat_rate, @vat_amt, @net_amt,  
									@invoice_flag, @comments, @active,
									@create_by)";
                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("invoice_no", Invoice.InvoiceNo);
                    cmd.Parameters.AddWithValue("invoice_date", Invoice.InvoiceDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("ref_document_no", Invoice.RefDocumentNo);
                    cmd.Parameters.AddWithValue("receipt_no", Invoice.ReceiptNo);
                    cmd.Parameters.AddWithValue("customer_code", Invoice.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("truck_id", Invoice.Truck.TruckId);
                    cmd.Parameters.AddWithValue("gross_amt", Invoice.GrossAmt);
                    cmd.Parameters.AddWithValue("disc_amt", Invoice.DiscAmt);
                    cmd.Parameters.AddWithValue("disc_amt_bill", Invoice.DiscAmtBill);
                    cmd.Parameters.AddWithValue("vat_rate", Invoice.VatRate);
                    cmd.Parameters.AddWithValue("vat_amt", Invoice.VatAmt);
                    cmd.Parameters.AddWithValue("net_amt", Invoice.NetAmt);
                    cmd.Parameters.AddWithValue("invoice_flag", Invoice.InvoiceFlag);
                    cmd.Parameters.AddWithValue("comments", Invoice.Comments);
                    //cmd.Parameters.AddWithValue("print_no", Invoice.PrintNo);
                    cmd.Parameters.AddWithValue("active", Invoice.Active);
                    cmd.Parameters.AddWithValue("create_by", Invoice.CreateBy);
                    cmd.ExecuteNonQuery();

                    sql = @"INSERT INTO invoice_item(
										invoice_no, product_code, seq,
										qty, wgh, unit_price_current, disc_per, unit_price,
										gross_amt, net_amt, sale_unit_method, create_by
									)
								VALUES (
										@invoice_no, @product_code, @seq,
										@qty, @wgh, @unit_price_current, @disc_per, @unit_price,
										@gross_amt, @net_amt, @sale_unit_method, @create_by )";

                    foreach (var item in Invoice.InvoiceItems)
                    {
                        cmd = new MySqlCommand(sql, conn)
                        {
                            Transaction = tr
                        };
                        cmd.Parameters.AddWithValue("invoice_no", Invoice.InvoiceNo);
                        cmd.Parameters.AddWithValue("product_code", item.Product.ProductCode);
                        cmd.Parameters.AddWithValue("seq", item.Seq);
                        cmd.Parameters.AddWithValue("qty", item.Qty);
                        cmd.Parameters.AddWithValue("wgh", item.Wgh);
                        cmd.Parameters.AddWithValue("unit_price_current", item.UnitPriceCurrent);
                        cmd.Parameters.AddWithValue("disc_per", item.DiscPer);
                        cmd.Parameters.AddWithValue("unit_price", item.UnitPrice);
                        cmd.Parameters.AddWithValue("gross_amt", item.GrossAmt);
                        cmd.Parameters.AddWithValue("net_amt", item.NetAmt);
                        cmd.Parameters.AddWithValue("sale_unit_method", item.SaleUnitMethod);
                        cmd.Parameters.AddWithValue("create_by", Invoice.CreateBy);
                        cmd.ExecuteNonQuery();
                    }

                    Int64 invoiceFlagOfSo = (Invoice.Active == true) ? 1 : 0;
                    sql = @"UPDATE orders
								SET invoice_flag=@invoice_flag
								WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("invoice_flag", invoiceFlagOfSo);
                    cmd.Parameters.AddWithValue("order_no", Invoice.RefDocumentNo);
                    cmd.ExecuteNonQuery();
                    tr.Commit();
                }
                return true;
            }
            catch (Exception)
            {
                tr.Rollback();
                throw;
            }
        }
        public static bool Update(Invoice Invoice)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = "";
                    //               sql = @"SELECT Invoice_flag FROM Invoice WHERE Invoice_no=@Invoice_no";
                    //var cmd = new MySqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("Invoice_no", Invoice.InvoiceNo);
                    //var InvoiceFlag = (int)cmd.ExecuteScalar();
                    //if (InvoiceFlag > 0)
                    //{
                    //	throw new Exception("ไม่สามารถยกเลิกเอกสารได้ \n\t เนื่องจากเอกสารได้นำไปใช้งานแล้ว");
                    //}
                    sql = @"UPDATE invoice
								SET invoice_date=@invoice_date,
								ref_document_no=@ref_document_no,
								receipt_no=@receipt_no,
								customer_code=@customer_code,
								truck_no=@truck_no, 
								gross_amt=@gross_amt,
								disc_amt=@disc_amt,
								disc_amt_bill=@disc_amt_bill,
								vat_rate=@vat_rate,
								vat_amt=@vat_amt,
								net_amt=@net_amt,  
								invoice_flag=@invoice_flag,
								comments=@comments,
								active=@active,
								modified_at=CURRENT_TIMESTAMP,
								modified_by=@modified_by
								WHERE invoice_no=@invoice_no";
                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("invoice_no", Invoice.InvoiceNo);
                    cmd.Parameters.AddWithValue("invoice_date", Invoice.InvoiceDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("ref_document_no", Invoice.RefDocumentNo);
                    cmd.Parameters.AddWithValue("receipt_no", Invoice.ReceiptNo);
                    cmd.Parameters.AddWithValue("customer_code", Invoice.Customer.CustomerCode);
                    cmd.Parameters.AddWithValue("truck_no", Invoice.Truck.TruckNo);
                    cmd.Parameters.AddWithValue("gross_amt", Invoice.GrossAmt);
                    cmd.Parameters.AddWithValue("disc_amt", Invoice.DiscAmt);
                    cmd.Parameters.AddWithValue("disc_amt_bill", Invoice.DiscAmtBill);
                    cmd.Parameters.AddWithValue("vat_rate", Invoice.VatRate);
                    cmd.Parameters.AddWithValue("vat_amt", Invoice.VatAmt);
                    cmd.Parameters.AddWithValue("net_amt", Invoice.NetAmt);
                    //cmd.Parameters.AddWithValue("print_no", Invoice.PrintNo);
                    cmd.Parameters.AddWithValue("invoice_flag", Invoice.InvoiceFlag);
                    cmd.Parameters.AddWithValue("comments", Invoice.Comments);
                    cmd.Parameters.AddWithValue("active", Invoice.Active);
                    cmd.Parameters.AddWithValue("modified_by", Invoice.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();

                    sql = @"Delete From invoice_item 
								WHERE invoice_no=@invoice_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("invoice_no", Invoice.InvoiceNo);
                    cmd.ExecuteNonQuery();

                    sql = @"INSERT INTO invoice_item(
										invoice_no, product_code, seq,
										qty, wgh, unit_price_current, disc_per, unit_price,
										gross_amt, net_amt, sale_unit_method, create_by 
									)
								VALUES ( 
										@invoice_no, @product_code, @seq,
										@qty, @wgh, @unit_price_current, @disc_per, @unit_price,
										@gross_amt, @net_amt, @sale_unit_method, @create_by )";

                    foreach (var item in Invoice.InvoiceItems)
                    {
                        cmd = new MySqlCommand(sql, conn)
                        {
                            Transaction = tr
                        };
                        cmd.Parameters.AddWithValue("invoice_no", Invoice.InvoiceNo);
                        cmd.Parameters.AddWithValue("product_code", item.Product.ProductCode);
                        cmd.Parameters.AddWithValue("seq", item.Seq);
                        cmd.Parameters.AddWithValue("qty", item.Qty);
                        cmd.Parameters.AddWithValue("wgh", item.Wgh);
                        cmd.Parameters.AddWithValue("unit_price_current", item.UnitPriceCurrent);
                        cmd.Parameters.AddWithValue("disc_per", item.DiscPer);
                        cmd.Parameters.AddWithValue("unit_price", item.UnitPrice);
                        cmd.Parameters.AddWithValue("gross_amt", item.GrossAmt);
                        cmd.Parameters.AddWithValue("net_amt", item.NetAmt);
                        cmd.Parameters.AddWithValue("sale_unit_method", item.SaleUnitMethod);
                        cmd.Parameters.AddWithValue("create_by", Invoice.CreateBy);
                        cmd.ExecuteNonQuery();
                    }

                    Int64 invoiceFlagOfSo = (Invoice.Active == true) ? 1 : 0;
                    sql = @"UPDATE orders
								SET invoice_flag=@invoice_flag
								WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("invoice_flag", invoiceFlagOfSo);
                    cmd.Parameters.AddWithValue("order_no", Invoice.RefDocumentNo);
                    cmd.ExecuteNonQuery();

                    tr.Commit();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool Cancel(Invoice Invoice)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = "";

                    sql = @"UPDATE invoice
								SET  active=@active,
                                comments=@comments,
								modified_at=CURRENT_TIMESTAMP,
								modified_by=@modified_by
								WHERE invoice_no=@invoice_no";
                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("invoice_no", Invoice.InvoiceNo);
                    cmd.Parameters.AddWithValue("active", Invoice.Active);
                    cmd.Parameters.AddWithValue("comments", Invoice.Comments);
                    cmd.Parameters.AddWithValue("modified_by", Invoice.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();

                    Int64 invoiceFlagOfSo = (Invoice.Active == true) ? 1 : 0;
                    sql = @"UPDATE orders
								SET invoice_flag=@invoice_flag
								WHERE order_no=@order_no";
                    cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("invoice_flag", invoiceFlagOfSo);
                    cmd.Parameters.AddWithValue("order_no", Invoice.RefDocumentNo);
                    cmd.ExecuteNonQuery();

                    tr.Commit();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdatePrintNo(string invoiceNo)
        {
            MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    var sql = "";

                    sql = @"UPDATE invoice
								SET  print_no=print_no+1
								WHERE invoice_no=@invoice_no";
                    var cmd = new MySqlCommand(sql, conn)
                    {
                        Transaction = tr
                    };
                    cmd.Parameters.AddWithValue("invoice_no", invoiceNo);
                    var affRow = cmd.ExecuteNonQuery();

                    tr.Commit();
                    return affRow;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string GetInvoiceNoByOrderNo(string orderNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT max(invoice_no)  as invoice_no
								FROM invoice
								WHERE ref_document_no =@orderNo 
                                   and active = 1 ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("orderNo", orderNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return (string)ds.Tables[0].Rows[0]["invoice_no"];
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
        public static DataSet GetDataPrintInvoice(string invoiceNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select i.invoice_no,
	                            i.invoice_date,	i.ref_document_no, i.customer_code,
	                            i.disc_amt, i.receipt_no,
	                            i.gross_amt as gross_amt_hd,
	                            i.disc_amt_bill as discount_hd,
	                            i.gross_amt - i.disc_amt_bill as before_vat,
	                            i.vat_rate as vat_rate_hd,
	                            i.vat_amt as vat_amt_hd,
	                            i.net_amt as net_amt_hd,
	                            i.invoice_flag,	i.comments, itm.product_code,
	                            p.product_name, u.unit_name, itm.seq,
	                            case when itm.sale_unit_method = 'Q' then itm.qty else itm.wgh end qty_wgh,
	                            itm.qty, itm.wgh, itm.unit_price,
	                            itm.gross_amt, c.customer_name, c.address,
	                            c.ship_to, c.tax_id, c.contact_no,
                                tk.truck_no, tk.driver,
	                            pl.plant_name, pl.address as plant_address, i.active,
                                pl.logo_image
                            from invoice i , invoice_item itm, 	product p, customer c, unit_of_measurement u, plant pl, truck tk
                            where i.invoice_no = @invoice_no
	                            and i.invoice_no = itm.invoice_no
	                            and itm.product_code = p.product_code
	                            and c.customer_code = i.customer_code
	                            and case when itm.sale_unit_method = 'Q' then p.unit_of_qty else unit_of_wgh end = u.unit_code
	                            and pl.plant_id = 1
                                and i.truck_id = tk.truck_id
								";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("invoice_no", invoiceNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetDataPrintTransport(string orderNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT
                                        t.transport_no,
                                        t.transport_date,
                                        t.ref_document_no,
                                        o.customer_code,
                                        c.customer_name,
                                        trk.truck_no,
                                        trk.driver,
                                        0 AS disc_amt,
                                        0 AS gross_amt_hd,
                                        0 AS discount_hd,
                                        0 AS before_vat,
                                        0 AS vat_rate_hd,
                                        0 AS vat_amt_hd,
                                        0 AS net_amt_hd,
                                        t.transport_flag,
                                        ti.product_code,
                                        p.product_name,
                                        ti.lot_no,
                                        u.unit_name,
                                        ti.seq,
                                        CASE
                                            WHEN p.sale_unit_method = 'Q' THEN ti.transport_qty
                                            ELSE ti.transport_wgh
                                        END qty_wgh,
                                        ti.transport_qty,
                                        ti.transport_wgh,
                                        0 AS unit_price,
                                        0 AS gross_amt,
                                        c.address,
                                        c.ship_to,
                                        c.tax_id,
                                        c.contact_no,
                                        pl.plant_name,
                                        pl.address AS plant_address
                                    FROM
                                        orders o,
                                        transport t,
                                        transport_item ti,
                                        truck trk,
                                        product p,
                                        customer c,
                                        unit_of_measurement u,
                                        plant pl
                                    WHERE
                                          t.ref_document_no = @order_no
                                        AND t.transport_no = ti.transport_no
                                        AND ti.truck_id = trk.truck_id
                                        AND o.order_no = t.ref_document_no
                                        AND ti.product_code = p.product_code
                                        AND c.customer_code = o.customer_code
                                        AND CASE
                                        WHEN p.sale_unit_method = 'Q' THEN p.unit_of_qty ELSE p.unit_of_wgh END = u.unit_code
                                        AND pl.plant_id = 1
								";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("order_no", orderNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<InvoiceInformation> GetInvoiceForExport()
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT
                        invoice_no,
                        invoice_date,
                        invoice.customer_code,
                        customer.customer_name,
                        net_amt
                    FROM
                        invoice,
                        customer
                    WHERE
                        invoice.customer_code = customer.customer_code
                    ORDER BY invoice_no";
                    var cmd = new MySqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("invoice_date", invoiceDate);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return null;
                    }
                    var invoices = new List<InvoiceInformation>();
                    var seq = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        invoices.Add(new InvoiceInformation()
                        {
                            Seq = seq,
                            InvoiceNo = item["invoice_no"].ToString(),
                            InvoiceDate = DateTime.Parse(item["invoice_date"].ToString()).ToString("dd-MM-yyyy"),
                            CustomerCode = item["customer_code"].ToString(),
                            CustomerName = item["customer_name"].ToString(),
                            Amount = item["net_amt"].ToString().ToDecimal(),
                            DocumantStatus = "",
                            Remark = "",
                        });
                        seq += 1;
                    }
                    return invoices;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void ImportCustomerClassPrice(List<CustomCustomerClassPrice> customerClassPrices)
        {
            try
            {
                var sqlDelete = @"DELETE FROM customer_class_price";
                var sqlInsert = @"INSERT into customer_class_price(class_id,product_code,start_date,end_date,unit_price,create_at,create_by)
                                        VALUES(@class_id,@product_code,@start_date,@end_date,@unit_price,@create_at,@create_by);";
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    using (MySqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            var cmd = new MySqlCommand(sqlDelete, conn, trans)
                            {
                                CommandType = CommandType.Text
                            };
                            cmd.ExecuteNonQuery();

                            cmd = new MySqlCommand(sqlInsert, conn, trans)
                            {
                                CommandType = CommandType.Text
                            };

                            foreach (var item in customerClassPrices)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@class_id", item.ClassId);
                                cmd.Parameters.AddWithValue("@product_code", item.ProductCode);
                                cmd.Parameters.AddWithValue("@start_date", item.StartDate);
                                cmd.Parameters.AddWithValue("@end_date", item.EndDate);
                                cmd.Parameters.AddWithValue("@unit_price", item.Price);
                                cmd.Parameters.AddWithValue("@create_at", DateTime.Now);
                                cmd.Parameters.AddWithValue("@create_by", "system");
                                cmd.ExecuteNonQuery();
                            }
                            trans.Commit();

                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public static class InvoiceItemController
    {
        public static DataTable GetInvoiceItems(string invoiceNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select a.invoice_no, a.seq,
								a.product_code,
								b.product_name,
								a.sale_unit_method,
								qty, wgh,
                                unit_price_current, disc_per,
								unit_price,
                                unit_disc,
                                disc_amt,
                                gross_amt
								from invoice_item a, product b
								where a.product_code =b.product_code
								and a.invoice_no =@invoice_no
								Order by seq asc";

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("invoice_no", invoiceNo);
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
    }

    public class InvoiceInformation
    {
        public int Seq { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }

        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string DocumantStatus { get; set; }
        public string Remark { get; set; }
    }
}
