using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace SlaughterHouseLib
{
    public class ReportController
    {
        readonly string connstr = System.Configuration.ConfigurationManager.AppSettings["connstr"].ToString();
        public static DataSet GetDataReportDailySales(DateTime invoiceDateStr, DateTime invoiceDateEnd)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT 
                                i.invoice_no,
                                i.invoice_date,
                                i.ref_document_no,
                                i.customer_code,
                                i.gross_amt AS gross_amt_hd,
                                i.discount AS discount_hd,
                                i.gross_amt - i.discount AS before_vat_hd,
                                i.vat_rate AS vat_rate_hd,
                                i.vat_amt AS vat_amt_hd,
                                i.net_amt AS net_amt_hd,
                                i.invoice_flag,
                                i.comments,
                                itm.product_code,
                                p.product_name,
                                u.unit_name,
                                itm.seq,
                                CASE
                                    WHEN itm.sale_unit_method = 'Q' THEN itm.qty
                                    ELSE itm.wgh
                                END qty_wgh,
                                itm.qty,
                                itm.wgh,
                                itm.unit_price,
                                itm.gross_amt,
                                0 as discount,
                                itm.gross_amt - 0 as before_vat,
                                0 as vat_amt,
                                0 as net_amt,
                                c.customer_name,
                                c.address,
                                c.ship_to,
                                c.tax_id,
                                c.contact_no,
                                pl.plant_name,
                                pl.address AS plant_address,
                                @show_date_str as date_str,
                                @show_date_end as date_end
                            FROM
                                invoice i,
                                invoice_item itm,
                                product p,
                                customer c,
                                unit_of_measurement u,
                                plant pl
                            WHERE i.invoice_date BETWEEN @invoice_date_str AND @invoice_date_end
		                        AND i.invoice_no = itm.invoice_no
                                AND itm.product_code = p.product_code
                                AND c.customer_code = i.customer_code
                                AND CASE
                                WHEN itm.sale_unit_method = 'Q' THEN p.unit_of_qty ELSE unit_of_wgh END = u.unit_code
                                AND pl.plant_id = 1
                                ";
                    //'2019-07-01 00:00:00' AND '2019-07-21 23:59:59'
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("invoice_date_str", invoiceDateStr);
                    cmd.Parameters.AddWithValue("invoice_date_end", invoiceDateEnd);

                    cmd.Parameters.AddWithValue("show_date_str", invoiceDateStr.ToString("dd/mm/yyyy"));
                    cmd.Parameters.AddWithValue("show_date_end", invoiceDateEnd.ToString("dd/mm/yyyy"));

                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["seq"].ToString() != "1")
                        {
                            ds.Tables[0].Rows[i]["gross_amt_hd"] = 0; 
                            ds.Tables[0].Rows[i]["discount_hd"] = 0; 
                            ds.Tables[0].Rows[i]["before_vat_hd"] = 0; 
                            ds.Tables[0].Rows[i]["vat_amt_hd"] = 0; 
                            ds.Tables[0].Rows[i]["net_amt_hd"] = 0;
                        }
                    }

                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static DataSet GetDataReportStockMovement(DateTime invoiceDateStr, DateTime invoiceDateEnd)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT
                                    sk.stock_date,
                                    sk.stock_no,
                                    sk.stock_item,
                                    sk.product_code,
                                    p.product_name,
                                    sk.stock_qty,
                                    sk.stock_wgh,
                                    sk.ref_document_type,
                                    sk.ref_document_no,
                                    sk.lot_no,
                                    sk.location_code,
                                    sk.barcode_no,
                                    sk.transaction_type,
                                    lo.location_name,
                                    dc.description,
                                    @show_date_str as date_str,
                                    @show_date_end as date_end,
                                    case when sk.transaction_type = 1 then 'รับ' else 'จ่าย' end as transaction_type_name
                                FROM
                                    stock sk
                                        INNER JOIN
                                    product p ON sk.product_code = p.product_code
                                        INNER JOIN
                                    location lo ON sk.location_code = lo.location_code
                                        LEFT JOIN
                                    document_generate dc ON sk.ref_document_type = dc.document_type
                                
                                "; //WHERE sk.stock_date BETWEEN @date_str AND @date_end
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("date_str", invoiceDateStr);
                    cmd.Parameters.AddWithValue("date_end", invoiceDateEnd);

                    cmd.Parameters.AddWithValue("show_date_str", invoiceDateStr.ToString("dd/mm/yyyy"));
                    cmd.Parameters.AddWithValue("show_date_end", invoiceDateEnd.ToString("dd/mm/yyyy"));

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

    }
}


