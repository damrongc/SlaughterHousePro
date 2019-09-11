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
                                AND CASE WHEN itm.sale_unit_method = 'Q' THEN p.unit_of_qty ELSE unit_of_wgh END = u.unit_code
                                AND pl.plant_id = 1
                                ";
                    //'2019-07-01 00:00:00' AND '2019-07-21 23:59:59'
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("invoice_date_str", invoiceDateStr.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("invoice_date_end", invoiceDateEnd.ToString("yyyy-MM-dd"));

                    cmd.Parameters.AddWithValue("show_date_str", invoiceDateStr.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("show_date_end", invoiceDateEnd.ToString("dd/MM/yyyy"));
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
                                    sk.lot_no, 
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
                                    pl.plant_name,
                                    pl.address AS plant_address,
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
                                        INNER JOIN 
                                    plant pl ON pl.plant_id = 1
                                WHERE sk.stock_date >= @date_str 
                                    AND sk.stock_date <= @date_end  
                                ";
                    // WHERE sk.stock_date BETWEEN @date_str AND @date_end
                    // AND sk.stock_date <= @date_end
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("show_date_str", invoiceDateStr.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("show_date_end", invoiceDateEnd.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("date_str", invoiceDateStr.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("date_end", invoiceDateEnd.ToString("yyyy-MM-dd"));
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

        public static DataSet GetDataReportStockBalance(DateTime invoiceDatePeriod)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT
	                                sk.product_code,
	                                p.product_name,
	                                sum(case when sk.transaction_type = 1 then sk.stock_qty else 0 end) as qty_in,
	                                sum(case when sk.transaction_type = 1 then sk.stock_wgh else 0 end) as wgh_in, 
	                                sum(case when sk.transaction_type = 2 then sk.stock_qty else 0 end) as qty_out,
	                                sum(case when sk.transaction_type = 2 then sk.stock_wgh else 0 end) as wgh_out,     
                                    0 as qty_cf,
                                    0 as wgh_cf,
	                                sk.lot_no, 
                                    uq.unit_name as unit_name_qty,
                                    uw.unit_name as unit_name_wgh,
                                pl.plant_name,
                                pl.address AS plant_address,
	                                DATE_FORMAT(@date_period, '%m-%Y')  as show_date_period 
                                FROM
	                                stock sk,
                                    product p,
	                                unit_of_measurement uq,
	                                unit_of_measurement uw,
                                    plant pl
                                where 1=1
                                and DATE_FORMAT(sk.stock_date, '%Y-%m-01') = DATE_FORMAT(@date_period, '%Y-%m-01') 
                                and sk.product_code = p.product_code 
                                and uq.unit_code = p.unit_of_qty 
                                and uw.unit_code = p.unit_of_wgh 
                                AND pl.plant_id = 1
                                group by sk.product_code,
	                                p.product_name, 
	                                sk.lot_no
                                ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("date_period", invoiceDatePeriod.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("show_date_period", invoiceDatePeriod.ToString("dd/MM/yyyy"));
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["qty_cf"] = Convert.ToDecimal(ds.Tables[0].Rows[i]["qty_in"]) - Convert.ToDecimal(ds.Tables[0].Rows[i]["qty_out"]);
                        ds.Tables[0].Rows[i]["wgh_cf"] = Convert.ToDecimal(ds.Tables[0].Rows[i]["wgh_in"]) - Convert.ToDecimal(ds.Tables[0].Rows[i]["wgh_out"]);
                    }
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetDataReportSoMapInv(DateTime invoiceDateStr, DateTime invoiceDateEnd)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select o.order_no, o.order_date, otm.product_code, po.product_name, 
                                CASE WHEN po.issue_unit_method = 'Q' THEN otm.order_qty ELSE otm.order_wgh END as qty_wgh, uo.unit_name,
                                i.invoice_no, i.invoice_date , itm.product_code as product_code_inv, pi.product_name as product_name_inv ,
                                itm.qty, itm.wgh, uiq.unit_name as unit_name_qty_inv, uiw.unit_name as unit_name_wgh_inv,
                                pl.plant_name, pl.address,
                                IFNULL(CASE WHEN po.issue_unit_method = 'Q' THEN otm.order_qty-itm.qty ELSE otm.order_wgh-itm.wgh END, 0) as qty_wgh_diff,
                                    @show_date_str as date_str,
                                    @show_date_end as date_end
                                from orders as o
	                                inner join orders_item as otm on o.order_no = otm.order_no
                                    left join invoice as i on i.ref_document_no = o.order_no
                                    left join invoice_item as itm on itm.invoice_no = i.invoice_no and itm.product_code = otm.product_code
                                    inner join plant as pl ON pl.plant_id = 1
                                    inner join product as po ON po.product_code = otm.product_code
                                    inner join unit_of_measurement as uo on uo.unit_code = CASE WHEN po.issue_unit_method = 'Q' THEN po.unit_of_qty else po.unit_of_wgh end
                                    left join product as pi ON pi.product_code = itm.product_code
                                    left join unit_of_measurement as uiq on uiq.unit_code = pi.unit_of_qty
                                    left join unit_of_measurement as uiw on uiw.unit_code = pi.unit_of_wgh
                                 WHERE o.order_date >= @date_str 
                                    AND o.order_date <= @date_end  
                                 order by o.order_date, o.order_no, i.invoice_date, i.invoice_no 
                                ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("date_str", invoiceDateStr.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("date_end", invoiceDateEnd.ToString("yyyy-MM-dd"));

                    cmd.Parameters.AddWithValue("show_date_str", invoiceDateStr.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("show_date_end", invoiceDateEnd.ToString("dd/MM/yyyy"));
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

        public static DataSet GetDataReceiveStickerBarcode(Int64 barcodeNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select b.barcode_no, b.product_code, p.product_name, b.qty, b.wgh,
                                    b.production_date, DATE_ADD(b.production_date, INTERVAL p.shelflife DAY) as expired_date, b.lot_no,
                                    p.issue_unit_method, uq.unit_name as unit_name_qty, uw.unit_name as unit_name_wgh
                                    from barcode b, product p, unit_of_measurement uq, unit_of_measurement uw
                                    where b.product_code = p.product_code
                                    and p.unit_of_qty = uq.unit_code
                                    and p.unit_of_wgh = uw.unit_code
                                    and b.barcode_no = @barcode_no
                                ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("barcode_no", barcodeNo);

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

        public static DataSet GetDataReportSwineReceiveHeader(string receiveNo)
        {
            try
            {
                var ds = new DataSet();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select receive_no,receive_date,transport_doc_no,
                                    truck_no,rev.farm_code,coop_no,queue_no,lot_no
                                    farm_qty,farm_wgh,factory_qty,factory_wgh,
                                    farm.farm_name,farm.address,
                                    breeder.breeder_name
                                    from receives rev,farm,breeder
                                    where receive_no =@receive_no
                                    and rev.farm_code =farm.farm_code
                                    and rev.breeder_code =breeder.breeder_code";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("receive_no", receiveNo);
                        var da = new MySqlDataAdapter(cmd);

                        da.Fill(ds);

                    }
                    sql = @"select receive_no,product_code,seq,sex_flag,receive_qty,receive_wgh
                                    from receive_item
                                    where receive_no =@receive_no
                                    and product_code ='P001'
                                    order by seq asc";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("receive_no", receiveNo);
                        var da = new MySqlDataAdapter(cmd);
                        var ds1 = new DataSet();
                        da.Fill(ds1);
                        var dt = new DataTable();
                        dt = ds1.Tables[0].Copy();
                        dt.TableName = "TableItem";
                        ds.Tables.Add(dt);
                    }

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


