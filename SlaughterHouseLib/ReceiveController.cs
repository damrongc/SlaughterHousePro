using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib
{
    public static class ReceiveController
    {
        public static object GetAllReceives(DateTime date, string farmCode = "", string transportNo = "")
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT a.receive_no,a.receive_date,a.transport_doc_no,");
                    sb.Append(" a.truck_no,a.farm_code,a.coop_no,");
                    sb.Append(" a.farm_qty,a.farm_wgh,");
                    sb.Append(" a.factory_qty,a.factory_wgh,");
                    sb.Append(" a.receive_flag,");
                    sb.Append(" a.queue_no,");
                    sb.Append(" b.farm_name,");
                    sb.Append(" c.breeder_name,a.create_at");
                    sb.Append(" FROM receives a,farm b,breeder c");
                    sb.Append(" WHERE a.farm_code =b.farm_code");
                    sb.Append(" AND a.breeder_code =c.breeder_code");

                    sb.Append(" AND a.receive_date=@receive_date");
                    if (!string.IsNullOrEmpty(farmCode))
                        sb.Append(" AND a.farm_code =@farm_code");
                    if (!string.IsNullOrEmpty(transportNo))
                        sb.Append(" AND a.transport_doc_no=@transport_doc_no");



                    sb.Append(" ORDER BY receive_no asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("receive_date", date.ToString("yyyy-MM-dd"));

                    if (!string.IsNullOrEmpty(farmCode))
                        cmd.Parameters.AddWithValue("farmCode", farmCode);
                    if (!string.IsNullOrEmpty(transportNo))
                        cmd.Parameters.AddWithValue("transport_doc_no", transportNo);


                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    ReceiveNo = p.Field<string>("receive_no"),
                                    ReceiveDate = p.Field<DateTime>("receive_date"),
                                    TransportDocNo = p.Field<string>("transport_doc_no"),
                                    TruckNo = p.Field<string>("truck_no"),
                                    FarmName = p.Field<string>("farm_name"),
                                    CoopNo = p.Field<string>("coop_no"),
                                    QueueNo = p.Field<int>("queue_no"),
                                    BreederName = p.Field<string>("breeder_name"),
                                    FarmQty = p.Field<int>("farm_qty"),
                                    FarmWgh = p.Field<decimal>("farm_wgh"),
                                    FactoryQty = p.Field<int>("factory_qty"),
                                    FactoryWgh = p.Field<decimal>("factory_wgh"),
                                    ReceiveFlag = p.Field<int>("factory_qty") == 0 ? "New" : (p.Field<int>("receive_flag") == 1 ? "Close" : "In Process"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                }).ToList();

                    return coll;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static object GetAllReceives(int receiveFlag)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sb = new StringBuilder();
                    sb.Append("SELECT a.receive_no,a.receive_date,a.transport_doc_no,");
                    sb.Append(" a.truck_no,a.farm_code,a.coop_no,");
                    sb.Append(" a.farm_qty,a.farm_wgh,");
                    sb.Append(" a.factory_qty,a.factory_wgh,");
                    sb.Append(" a.receive_flag,");
                    sb.Append(" a.queue_no,");
                    sb.Append(" b.farm_name,");
                    sb.Append(" c.breeder_name,a.create_at");
                    sb.Append(" FROM receives a,farm b,breeder c");
                    sb.Append(" WHERE a.farm_code =b.farm_code");
                    sb.Append(" AND a.breeder_code =c.breeder_code");
                    sb.Append(" AND a.receive_flag = @receive_flag");
                    sb.Append(" ORDER BY receive_no asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);

                    cmd.Parameters.AddWithValue("receive_flag", receiveFlag);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    ReceiveNo = p.Field<string>("receive_no"),
                                    ReceiveDate = p.Field<DateTime>("receive_date"),
                                    TransportDocNo = p.Field<string>("transport_doc_no"),
                                    TruckNo = p.Field<string>("truck_no"),
                                    FarmName = p.Field<string>("farm_name"),
                                    CoopNo = p.Field<string>("coop_no"),
                                    QueueNo = p.Field<int>("queue_no"),
                                    BreederName = p.Field<string>("breeder_name"),
                                    FarmQty = p.Field<int>("farm_qty"),
                                    FarmWgh = p.Field<decimal>("farm_wgh"),
                                    //FactoryQty = p.Field<int>("factory_qty"),
                                    //FactoryWgh = p.Field<decimal>("factory_wgh"),
                                    //ReceiveFlag = p.Field<int>("receive_flag") == 0 ? "New" : (p.Field<int>("receive_flag") == 1 ? "In Process" : "Finish"),
                                    //CreateAt = p.Field<DateTime>("create_at"),
                                }).ToList();

                    return coll;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Receive GetReceive(string receiveNo)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT 
                                a.receive_no,
                                a.receive_date,
                                a.transport_doc_no,
                                a.truck_no,
                                a.farm_code,
                                a.coop_no,
                                a.breeder_code,
                                a.queue_no,
                                a.farm_qty,
                                a.farm_wgh,
                                a.factory_qty,
                                a.factory_wgh,
                                a.receive_flag,
                                b.farm_name,
                                c.breeder_name
                                FROM receives a,farm b,breeder c
                                WHERE a.farm_code =b.farm_code
                                AND a.breeder_code =c.breeder_code
                                AND receive_no =@receive_no";


                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("receive_no", receiveNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return new Receive
                        {

                            ReceiveNo = (string)ds.Tables[0].Rows[0]["receive_no"],
                            ReceiveDate = (DateTime)ds.Tables[0].Rows[0]["receive_date"],
                            TransportDocNo = (string)ds.Tables[0].Rows[0]["transport_doc_no"],

                            TruckNo = (string)ds.Tables[0].Rows[0]["truck_no"],

                            Farm = new Farm
                            {
                                FarmCode = (string)ds.Tables[0].Rows[0]["farm_code"],
                                FarmName = (string)ds.Tables[0].Rows[0]["farm_name"]

                            },


                            CoopNo = ds.Tables[0].Rows[0]["coop_no"].ToString(),
                            Breeder = new Breeder
                            {
                                BreederCode = (int)ds.Tables[0].Rows[0]["breeder_code"],
                                BreederName = (string)ds.Tables[0].Rows[0]["breeder_name"]
                            },

                            QueueNo = (int)ds.Tables[0].Rows[0]["queue_no"],
                            FarmQty = (int)ds.Tables[0].Rows[0]["farm_qty"],
                            FarmWgh = (decimal)ds.Tables[0].Rows[0]["farm_wgh"],

                            FactoryQty = (int)ds.Tables[0].Rows[0]["factory_qty"],
                            FactoryWgh = (decimal)ds.Tables[0].Rows[0]["factory_wgh"],
                            ReceiveFlag = (int)ds.Tables[0].Rows[0]["receive_flag"],
                            //CreateAt = (DateTime)ds.Tables[0].Rows[0]["create_at"],
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

        public static Receive GetReceive(string receiveNo, string productCode)
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT x.*,y.farm_name,z.breeder_name
                                FROM 
                                    (SELECT a.receive_no,
                                    a.receive_date,
                                    a.transport_doc_no,
                                    a.truck_no,
                                    a.farm_code,
                                    a.coop_no,
                                    a.breeder_code,
                                    a.queue_no,
                                    a.farm_qty,
                                    a.farm_wgh,
                                    IFNULL(SUM(receive_qty),0) as factory_qty,
                                    IFNULL(SUM(receive_wgh),0) as factory_wgh
                                    FROM receives a 
                                    LEFT JOIN receive_item b 
                                    ON a.receive_no=b.receive_no
                                    WHERE  a.receive_no =@receive_no
                                    AND b.product_code =@product_code
                                ) x,farm y,breeder z
                                WHERE x.farm_code =y.farm_code
                                AND x.breeder_code =z.breeder_code";


                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("receive_no", receiveNo);
                    cmd.Parameters.AddWithValue("product_code", productCode);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    Receive receive = new Receive();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {


                        receive.ReceiveNo = (string)ds.Tables[0].Rows[i]["receive_no"];
                        receive.ReceiveDate = (DateTime)ds.Tables[0].Rows[i]["receive_date"];
                        receive.TransportDocNo = (string)ds.Tables[0].Rows[i]["transport_doc_no"];
                        receive.TruckNo = (string)ds.Tables[0].Rows[i]["truck_no"];
                        receive.Farm = new Farm
                        {
                            FarmCode = (string)ds.Tables[0].Rows[i]["farm_code"],
                            FarmName = (string)ds.Tables[0].Rows[i]["farm_name"]

                        };
                        receive.CoopNo = ds.Tables[0].Rows[i]["coop_no"].ToString();
                        receive.Breeder = new Breeder
                        {
                            BreederCode = ds.Tables[0].Rows[i]["breeder_code"].ToString().ToInt16(),
                            BreederName = (string)ds.Tables[0].Rows[i]["breeder_name"]
                        };
                        receive.QueueNo = ds.Tables[0].Rows[i]["queue_no"].ToString().ToInt16();
                        receive.FarmQty = ds.Tables[0].Rows[i]["farm_qty"].ToString().ToInt16();
                        receive.FarmWgh = ds.Tables[0].Rows[i]["farm_wgh"].ToString().ToDecimal();
                        receive.FactoryQty = ds.Tables[0].Rows[i]["factory_qty"].ToString().ToInt16();
                        receive.FactoryWgh = ds.Tables[0].Rows[i]["factory_wgh"].ToString().ToDecimal();
                    }
                    return receive;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool InsertOrUpdate(Receive receive)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    if (string.IsNullOrEmpty(receive.ReceiveNo))
                    {
                        //ADD NEW
                        var sql = @"SELECT MAX(queue_no)
                                    FROM receives 
                                    WHERE receive_date=@receive_date";

                        var cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("receive_date", receive.ReceiveDate.ToString("yyyy/MM/dd"));
                        var queue_no = cmd.ExecuteScalar();
                        if (queue_no == null)
                            receive.QueueNo = 1;
                        else
                            receive.QueueNo = queue_no.ToString().ToInt16() + 1;


                        receive.ReceiveNo = DocumentGenerate.GetDocumentRunning("REV");
                        receive.ReceiveDate = DateTime.Today;


                        sql = @"INSERT INTO receives(
                                receive_no,
                                receive_date,
                                transport_doc_no,
                                truck_no,
                                farm_code,
                                coop_no,
                                breeder_code,
                                queue_no,
                                farm_qty,
                                farm_wgh,
                                receive_flag,
                                create_by)
                                VALUES(
                                @receive_no,
                                @receive_date,
                                @transport_doc_no,
                                @truck_no,
                                @farm_code,
                                @coop_no,
                                @breeder_code,
                                @queue_no,
                                @farm_qty,
                                @farm_wgh,
                                @receive_flag,
                                @create_by)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("receive_no", receive.ReceiveNo);
                        cmd.Parameters.AddWithValue("receive_date", receive.ReceiveDate);
                        cmd.Parameters.AddWithValue("transport_doc_no", receive.TransportDocNo);
                        cmd.Parameters.AddWithValue("truck_no", receive.TruckNo);
                        cmd.Parameters.AddWithValue("farm_code", receive.Farm.FarmCode);
                        cmd.Parameters.AddWithValue("coop_no", receive.CoopNo);
                        cmd.Parameters.AddWithValue("breeder_code", receive.Breeder.BreederCode);
                        cmd.Parameters.AddWithValue("queue_no", receive.QueueNo);
                        cmd.Parameters.AddWithValue("farm_qty", receive.FarmQty);
                        cmd.Parameters.AddWithValue("farm_wgh", receive.FarmWgh);
                        cmd.Parameters.AddWithValue("receive_flag", receive.ReceiveFlag);
                        cmd.Parameters.AddWithValue("create_by", receive.CreateBy);
                        cmd.ExecuteNonQuery();


                    }
                    else
                    {
                        //UPDATE
                        var sql = @"UPDATE receives SET 
                                transport_doc_no=@transport_doc_no,
                                truck_no=@truck_no,
                                farm_code=@farm_code,
                                coop_no=@coop_no,
                                breeder_code=@breeder_code,
                                farm_qty=@farm_qty,
                                farm_wgh=@farm_wgh,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE receive_no=@receive_no";
                        var cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("receive_no", receive.ReceiveNo);
                        cmd.Parameters.AddWithValue("transport_doc_no", receive.TransportDocNo);
                        cmd.Parameters.AddWithValue("truck_no", receive.TruckNo);
                        cmd.Parameters.AddWithValue("farm_code", receive.Farm.FarmCode);
                        cmd.Parameters.AddWithValue("coop_no", receive.CoopNo);
                        cmd.Parameters.AddWithValue("breeder_code", receive.Breeder.BreederCode);
                        cmd.Parameters.AddWithValue("farm_qty", receive.FarmQty);
                        cmd.Parameters.AddWithValue("farm_wgh", receive.FarmWgh);
                        cmd.Parameters.AddWithValue("modified_by", receive.ModifiedBy);
                        cmd.ExecuteNonQuery();
                    }



                    //sql = @"NSERT INTO receive_item(
                    //            receive_no,
                    //            seq,
                    //            sex_flag,
                    //            receive_qty,
                    //            receive_wgh,
                    //            create_by)
                    //            VALUES(
                    //            @receive_no,
                    //            @queue_no,
                    //            @seq,
                    //            @product_code,
                    //            @sex_flag,
                    //            @receive_qty,
                    //            @receive_wgh,
                    //            @create_by)";

                    //foreach (var item in receive.ReceiveItems)
                    //{
                    //    cmd = new MySqlCommand(sql, conn)
                    //    {
                    //        Transaction = tr
                    //    };
                    //    cmd.Parameters.AddWithValue("receive_no", receive.ReceiveNo);
                    //    cmd.Parameters.AddWithValue("seq", item.Seq);
                    //    cmd.Parameters.AddWithValue("sex_flag", item.SexFlag);
                    //    cmd.Parameters.AddWithValue("receive_qty", item.ReceiveQty);
                    //    cmd.Parameters.AddWithValue("receive_wgh", item.ReceiveWgh);
                    //    cmd.Parameters.AddWithValue("create_by", receive.CreateBy);
                    //    cmd.ExecuteNonQuery();
                    //}
                    //tr.Commit();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static bool Update(Receive receive)
        //{
        //    try
        //    {
        //        using (var conn = new MySqlConnection(Globals.CONN_STR))
        //        {
        //            conn.Open();
        //            var sql = @"UPDATE receives SET 
        //                        transport_doc_no=@transport_doc_no,
        //                        truck_no=@truck_no,
        //                        farm_code=@farm_code,
        //                        coop_no=@coop_no,
        //                        breeder_code=@breeder_code,
        //                        farm_qty=@farm_qty,
        //                        farm_wgh=@farm_wgh,
        //                        receive_flag=@receive_flag,
        //                        modified_at=CURRENT_TIMESTAMP,
        //                        modified_by=@modified_by
        //                        WHERE receive_no=@receive_no";
        //            var cmd = new MySqlCommand(sql, conn);
        //            cmd.Parameters.AddWithValue("receive_no", receive.ReceiveNo);
        //            cmd.Parameters.AddWithValue("transport_doc_no", receive.TransportDocNo);
        //            cmd.Parameters.AddWithValue("truck_no", receive.TruckNo);
        //            cmd.Parameters.AddWithValue("farm_code", receive.Farm.FarmCode);
        //            cmd.Parameters.AddWithValue("coop_no", receive.CoopNo);
        //            cmd.Parameters.AddWithValue("breeder_code", receive.Breeder.BreederCode);
        //            cmd.Parameters.AddWithValue("farm_qty", receive.FarmQty);
        //            cmd.Parameters.AddWithValue("farm_wgh", receive.FarmWgh);
        //            cmd.Parameters.AddWithValue("receive_flag", receive.ReceiveFlag);
        //            cmd.Parameters.AddWithValue("modified_by", receive.ModifiedBy);
        //            cmd.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public static bool Delete(string receiveNo)
        {
            //MySqlTransaction tr = null;
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    //tr = conn.BeginTransaction();

                    //Check Flag
                    // 0 = New Create
                    // 1 = Next State 
                    var sql = @"SELECT receive_flag FROM receives WHERE receive_no=@receive_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("receive_no", receiveNo);
                    var flag = (int)cmd.ExecuteScalar();
                    if (flag > 0)
                    {
                        throw new Exception("ไม่สามารถยกเลิกเอกสารได้ \n\t เนื่องจากเอกสารได้นำไปใช้งานแล้ว");
                    }

                    //Delete All Receive
                    sql = @"DELETE FROM receive_item WHERE receive_no=@receive_no;
                            DELETE FROM receives WHERE receive_no=@receive_no";
                    cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("receive_no", receiveNo);
                    cmd.ExecuteNonQuery();

                    //Delete Receive
                    //sql = @"DELETE FROM receives WHERE receive_no=@receive_no";
                    //cmd = new MySqlCommand(sql, conn)
                    //{
                    //    Transaction = tr
                    //};
                    //cmd.Parameters.AddWithValue("receive_no", receiveNo);
                    //cmd.ExecuteNonQuery();

                    //tr.Commit();
                }
                return true;
            }
            catch (Exception)
            {
                //tr.Rollback();
                throw;
            }
        }

        public static List<ReceiveItem> GetItems(string receiveNo)
        {
            try
            {
                var receiveItems = new List<ReceiveItem>();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"select a.order_no,
                                a.seq,
                                receive_qty,
                                receive_wgh,
                                b.product_name
                                from receive_item a,product b
                                where a.product_code =b.product_code
                                and receive_no =@receive_no
                                order by queue_no,seq asc";


                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("receive_no", receiveNo);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        receiveItems.Add(new ReceiveItem
                        {
                            ReceiveNo = (string)item["receive_no"],
                            //QueueNo = (string)item["queue_no"],
                            Seq = (int)item["seq"],
                            //Product = new Product
                            //{
                            //    ProductCode = item["product_code"].ToString(),
                            //    ProductName = item["product_name"].ToString(),
                            //},
                            SexFlag = (string)item["sex_flag"],
                            ReceiveQty = (int)item["receive_qty"],
                            ReceiveWgh = (decimal)item["receive_wgh"],

                        });
                    }

                }

                return receiveItems;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool InsertItem(ReceiveItem receiveItem)
        {
            var conn = new MySqlConnection(Globals.CONN_STR);
            MySqlTransaction transaction = null;
            try
            {

                conn.Open();

                Receive receive = GetReceive(receiveItem.ReceiveNo);


                var sql = @"SELECT max(seq) as seq,sum(receive_qty) as receive_qty
                                FROM receive_item 
                                WHERE receive_no=@receive_no
                                AND product_code=@product_code
                                GROUP BY receive_no,product_code";
                var cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("receive_no", receiveItem.ReceiveNo);
                cmd.Parameters.AddWithValue("product_code", receiveItem.ProductCode);
                var da = new MySqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);

                var sumReceiveQty = 0;
                if (ds.Tables[0].Rows.Count == 0)
                {
                    receiveItem.Seq = 1;
                }
                else
                {
                    sumReceiveQty = ds.Tables[0].Rows[0]["receive_qty"].ToString().ToInt16();
                    receiveItem.Seq += ds.Tables[0].Rows[0]["seq"].ToString().ToInt16() + 1;
                }
                var remainQty = receive.FactoryQty - sumReceiveQty;
                if (remainQty == 0)
                {
                    throw new Exception("ไม่สามารถรับสินค้าได้ เนื่องจากรับสินค้าครบแล้ว!");
                }

                //if (string.IsNullOrEmpty(seq))
                //{
                //    receiveItem.Seq = 1;
                //}
                //else
                //{
                //    receiveItem.Seq += seq.ToInt16() + 1;
                //}

                transaction = conn.BeginTransaction();

                sql = @"INSERT INTO receive_item(
                                receive_no,
                                product_code,
                                seq,
                                sex_flag,
                                receive_qty,
                                receive_wgh,
                                create_by)
                                VALUES(
                                @receive_no,
                                @product_code,
                                @seq,
                                @sex_flag,
                                @receive_qty,
                                @receive_wgh,
                                @create_by)";
                cmd = new MySqlCommand()
                {
                    Connection = conn,
                    CommandText = sql,
                    Transaction = transaction
                };

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("receive_no", receiveItem.ReceiveNo);
                cmd.Parameters.AddWithValue("product_code", receiveItem.ProductCode);
                cmd.Parameters.AddWithValue("seq", receiveItem.Seq);
                //cmd.Parameters.AddWithValue("product_code", receiveItem.Product.ProductCode);
                cmd.Parameters.AddWithValue("sex_flag", receiveItem.SexFlag);
                cmd.Parameters.AddWithValue("receive_qty", receiveItem.ReceiveQty);
                cmd.Parameters.AddWithValue("receive_wgh", receiveItem.ReceiveWgh);
                cmd.Parameters.AddWithValue("create_by", receiveItem.CreateBy);
                cmd.ExecuteNonQuery();


                if (receive.ReceiveFlag == 0)
                {
                    //Update FactoryQty,FactoryWgh
                    sql = @"UPDATE receives SET 
                            factory_qty=factory_qty + @factory_qty,
                            factory_wgh=factory_wgh + @factory_wgh
                            WHERE receive_no=@receive_no";
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("receive_no", receiveItem.ReceiveNo);
                    cmd.Parameters.AddWithValue("factory_qty", receiveItem.ReceiveQty);
                    cmd.Parameters.AddWithValue("factory_wgh", receiveItem.ReceiveWgh);
                    cmd.ExecuteNonQuery();
                }


                // Commit the transaction.
                transaction.Commit();
                return true;



            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

    }


}
