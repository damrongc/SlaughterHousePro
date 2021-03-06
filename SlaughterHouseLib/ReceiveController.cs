﻿using MySql.Data.MySqlClient;
using SlaughterHouseLib.Models;
using System;
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
                    sb.Append(" a.truck_id,a.farm_code,a.coop_no,");
                    sb.Append(" a.farm_qty,a.farm_wgh,");
                    sb.Append(" a.factory_qty,a.factory_wgh,");
                    sb.Append(" a.receive_flag,");
                    sb.Append(" a.queue_no,");
                    sb.Append(" b.farm_name,");
                    sb.Append(" c.breeder_name,a.create_at,d.truck_no");
                    sb.Append(" FROM receives a,farm b,breeder c,truck d");
                    sb.Append(" WHERE a.farm_code =b.farm_code");
                    sb.Append(" AND a.breeder_code =c.breeder_code");
                    sb.Append(" AND a.truck_id =d.truck_id");
                    sb.Append(" AND a.receive_date=@receive_date");
                    if (!string.IsNullOrEmpty(farmCode))
                        sb.Append(" AND a.farm_code =@farm_code");
                    if (!string.IsNullOrEmpty(transportNo))
                        sb.Append(" AND a.transport_doc_no=@transport_doc_no");



                    sb.Append(" ORDER BY receive_no asc");
                    var cmd = new MySqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("receive_date", date.ToString("yyyy-MM-dd"));

                    if (!string.IsNullOrEmpty(farmCode))
                        cmd.Parameters.AddWithValue("farm_code", farmCode);
                    if (!string.IsNullOrEmpty(transportNo))
                        cmd.Parameters.AddWithValue("transport_doc_no", transportNo);


                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    ReceiveNo = p.Field<string>("receive_no"),
                                    ReceiveDate = p.Field<DateTime>("receive_date").ToString("dd-MM-yyyy"),
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
                                    ReceiveFlag = p.Field<int>("factory_qty") == 0 ? "New" : (p.Field<int>("receive_flag") == 1 ? "In Process" : "Close"),
                                    CreateAt = p.Field<DateTime>("create_at").ToString("dd-MM-yyyy HH:mm"),
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
                    var sql = @"SELECT a.receive_no,a.receive_date,a.transport_doc_no,
                                a.truck_id,a.farm_code,a.coop_no,
                                a.farm_qty,a.farm_wgh,
                                a.factory_qty,a.factory_wgh,
                                a.receive_flag,
                                a.queue_no,
                                b.farm_name,
                                c.breeder_name,a.create_at,d.truck_no
                                FROM receives a,farm b,breeder c,truck d
                                WHERE a.farm_code =b.farm_code
                                AND a.breeder_code =c.breeder_code
                                AND a.truck_id =d.truck_id
                                AND a.receive_flag = @receive_flag
                                ORDER BY receive_no asc";

                    var cmd = new MySqlCommand(sql, conn);

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
                                    TruckId = p.Field<Int32>("truck_id"),
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
                                a.truck_id,
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
                                c.breeder_name,
                                d.truck_no
                                FROM receives a,farm b,breeder c,truck d
                                WHERE a.farm_code =b.farm_code
                                AND a.breeder_code =c.breeder_code
                                AND a.truck_id =d.truck_id
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
                            Truck = new Truck
                            {
                                TruckId = (int)ds.Tables[0].Rows[0]["truck_id"],
                                //TruckNo = (string)ds.Tables[0].Rows[0]["truck_no"],
                            },
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

        //public static Receive GetReceive(string receiveNo, string productCode)
        //{
        //    try
        //    {

        //        using (var conn = new MySqlConnection(Globals.CONN_STR))
        //        {
        //            conn.Open();
        //            var sql = @"SELECT x.*,y.farm_name,z.breeder_name
        //                        FROM
        //                            (SELECT a.receive_no,
        //                            a.receive_date,
        //                            a.transport_doc_no,
        //                            a.truck_no,
        //                            a.farm_code,
        //                            a.coop_no,
        //                            a.breeder_code,
        //                            a.queue_no,
        //                            a.farm_qty,
        //                            a.farm_wgh,
        //                            IFNULL(SUM(receive_qty),0) as factory_qty,
        //                            IFNULL(SUM(receive_wgh),0) as factory_wgh
        //                            FROM receives a
        //                            LEFT JOIN receive_item b
        //                            ON a.receive_no=b.receive_no
        //                            WHERE  a.receive_no =@receive_no
        //                            AND b.product_code =@product_code
        //                        ) x,farm y,breeder z
        //                        WHERE x.farm_code =y.farm_code
        //                        AND x.breeder_code =z.breeder_code";


        //            var cmd = new MySqlCommand(sql, conn);
        //            cmd.Parameters.AddWithValue("receive_no", receiveNo);
        //            cmd.Parameters.AddWithValue("product_code", productCode);
        //            var da = new MySqlDataAdapter(cmd);

        //            var ds = new DataSet();
        //            da.Fill(ds);

        //            Receive receive = new Receive();
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {


        //                receive.ReceiveNo = (string)ds.Tables[0].Rows[i]["receive_no"];
        //                receive.ReceiveDate = (DateTime)ds.Tables[0].Rows[i]["receive_date"];
        //                receive.TransportDocNo = (string)ds.Tables[0].Rows[i]["transport_doc_no"];
        //                receive.TruckNo = (string)ds.Tables[0].Rows[i]["truck_no"];
        //                receive.Farm = new Farm
        //                {
        //                    FarmCode = (string)ds.Tables[0].Rows[i]["farm_code"],
        //                    FarmName = (string)ds.Tables[0].Rows[i]["farm_name"]

        //                };
        //                receive.CoopNo = ds.Tables[0].Rows[i]["coop_no"].ToString();
        //                receive.Breeder = new Breeder
        //                {
        //                    BreederCode = ds.Tables[0].Rows[i]["breeder_code"].ToString().ToInt16(),
        //                    BreederName = (string)ds.Tables[0].Rows[i]["breeder_name"]
        //                };
        //                receive.QueueNo = ds.Tables[0].Rows[i]["queue_no"].ToString().ToInt16();
        //                receive.FarmQty = ds.Tables[0].Rows[i]["farm_qty"].ToString().ToInt16();
        //                receive.FarmWgh = ds.Tables[0].Rows[i]["farm_wgh"].ToString().ToDecimal();
        //                receive.FactoryQty = ds.Tables[0].Rows[i]["factory_qty"].ToString().ToInt16();
        //                receive.FactoryWgh = ds.Tables[0].Rows[i]["factory_wgh"].ToString().ToDecimal();
        //            }
        //            return receive;

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public static bool InsertOrUpdate(Receive receive)
        {
            try
            {
                var plant = PlantController.GetPlant();
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    if (string.IsNullOrEmpty(receive.ReceiveNo))
                    {
                        //ADD NEW
                        var sql = @"SELECT MAX(queue_no)
                                    FROM receives
                                    WHERE receive_date=@receive_date
                                    GROUP BY receive_no";

                        var cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("receive_date", receive.ReceiveDate.ToString("yyyy/MM/dd"));
                        var queue_no = cmd.ExecuteScalar();
                        if (queue_no == null)
                            receive.QueueNo = 1;
                        else
                            receive.QueueNo = queue_no.ToString().ToInt16() + 1;

                        receive.ReceiveNo = DocumentGenerate.GetDocumentRunningFormat("REV", receive.ReceiveDate);
                        receive.LotNo = DocumentGenerate.GetSwineLotNo(plant.PlantId, receive.QueueNo);
                        sql = @"INSERT INTO receives(
                                receive_no,
                                receive_date,
                                transport_doc_no,
                                truck_id,
                                farm_code,
                                coop_no,
                                breeder_code,
                                queue_no,
                                lot_no,
                                farm_qty,
                                farm_wgh,
                                receive_flag,
                                create_by)
                                VALUES(
                                @receive_no,
                                @receive_date,
                                @transport_doc_no,
                                @truck_id,
                                @farm_code,
                                @coop_no,
                                @breeder_code,
                                @queue_no,
                                @lot_no,
                                @farm_qty,
                                @farm_wgh,
                                @receive_flag,
                                @create_by)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("receive_no", receive.ReceiveNo);
                        cmd.Parameters.AddWithValue("receive_date", receive.ReceiveDate);
                        cmd.Parameters.AddWithValue("transport_doc_no", receive.TransportDocNo);
                        cmd.Parameters.AddWithValue("truck_id", receive.Truck.TruckId);
                        cmd.Parameters.AddWithValue("farm_code", receive.Farm.FarmCode);
                        cmd.Parameters.AddWithValue("coop_no", receive.CoopNo);
                        cmd.Parameters.AddWithValue("breeder_code", receive.Breeder.BreederCode);
                        cmd.Parameters.AddWithValue("queue_no", receive.QueueNo);
                        cmd.Parameters.AddWithValue("lot_no", receive.LotNo);
                        cmd.Parameters.AddWithValue("farm_qty", receive.FarmQty);
                        cmd.Parameters.AddWithValue("farm_wgh", receive.FarmWgh);
                        cmd.Parameters.AddWithValue("receive_flag", receive.ReceiveFlag);
                        cmd.Parameters.AddWithValue("create_by", receive.CreateBy);
                        cmd.ExecuteNonQuery();


                        //sql = @"INSERT INTO receive_item_by_product(
                        //            receive_no,
                        //            bom_product_code,
                        //            product_code,
                        //            lot_no,
                        //            target_qty,
                        //            target_wgh,
                        //            actual_qty,
                        //            actual_wgh,
                        //            create_by
                        //        )VALUES(
                        //            @receive_no,
                        //            @bom_product_code,
                        //            @product_code,
                        //            @lot_no,
                        //            @target_qty,
                        //            @target_wgh,
                        //            @actual_qty,
                        //            @actual_wgh,
                        //            @create_by
                        //        )";
                        ////GET BOM
                        ////00101 เครื่องในแดง
                        //List<string> list = BomItemController.GetBomItemByProductCode("00101");
                        //list.Add("00101");
                        ////INSERT By PRODUCT
                        //foreach (var item in list)
                        //{
                        //    int target_qty = item == "00101" ? (receive.FarmQty * (list.Count - 1)) : receive.FarmQty;
                        //    cmd = new MySqlCommand(sql, conn);
                        //    cmd.Parameters.AddWithValue("receive_no", receive.ReceiveNo);
                        //    cmd.Parameters.AddWithValue("bom_product_code", "00101");
                        //    cmd.Parameters.AddWithValue("product_code", item);
                        //    cmd.Parameters.AddWithValue("lot_no", receive.LotNo);
                        //    cmd.Parameters.AddWithValue("target_qty", target_qty == 0 ? receive.FarmQty : target_qty);
                        //    cmd.Parameters.AddWithValue("target_wgh", receive.FarmWgh);
                        //    cmd.Parameters.AddWithValue("actual_qty", 0);
                        //    cmd.Parameters.AddWithValue("actual_wgh", 0);
                        //    cmd.Parameters.AddWithValue("create_by", receive.CreateBy);
                        //    cmd.ExecuteNonQuery();
                        //}
                        //list.Clear();
                        ////00201 เครื่องในขาว
                        //list = BomItemController.GetBomItemByProductCode("00201");
                        //list.Add("00201");
                        ////INSERT By PRODUCT
                        //foreach (var item in list)
                        //{
                        //    int target_qty = item == "00201" ? (receive.FarmQty * (list.Count - 1)) : receive.FarmQty;
                        //    cmd = new MySqlCommand(sql, conn);
                        //    cmd.Parameters.AddWithValue("receive_no", receive.ReceiveNo);
                        //    cmd.Parameters.AddWithValue("bom_product_code", "00201");
                        //    cmd.Parameters.AddWithValue("product_code", item);
                        //    cmd.Parameters.AddWithValue("lot_no", receive.LotNo);
                        //    cmd.Parameters.AddWithValue("target_qty", target_qty == 0 ? receive.FarmQty : target_qty);
                        //    cmd.Parameters.AddWithValue("target_wgh", receive.FarmWgh);
                        //    cmd.Parameters.AddWithValue("actual_qty", 0);
                        //    cmd.Parameters.AddWithValue("actual_wgh", 0);
                        //    cmd.Parameters.AddWithValue("create_by", receive.CreateBy);
                        //    cmd.ExecuteNonQuery();
                        //}
                    }
                    else
                    {
                        //UPDATE
                        var sql = @"UPDATE receives SET
                                transport_doc_no=@transport_doc_no,
                                truck_id=@truck_id,
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
                        cmd.Parameters.AddWithValue("truck_id", receive.Truck.TruckId);
                        cmd.Parameters.AddWithValue("farm_code", receive.Farm.FarmCode);
                        cmd.Parameters.AddWithValue("coop_no", receive.CoopNo);
                        cmd.Parameters.AddWithValue("breeder_code", receive.Breeder.BreederCode);
                        cmd.Parameters.AddWithValue("farm_qty", receive.FarmQty);
                        cmd.Parameters.AddWithValue("farm_wgh", receive.FarmWgh);
                        cmd.Parameters.AddWithValue("modified_by", receive.ModifiedBy);
                        cmd.ExecuteNonQuery();
                    }

                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

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
                    var sql = @"SELECT count(1) FROM receive_item WHERE receive_no=@receive_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("receive_no", receiveNo);
                    var count = cmd.ExecuteScalar();
                    if (count.ToString().ToInt16() > 0)
                    {
                        throw new Exception("ไม่สามารถยกเลิกเอกสารได้ \n\t เนื่องจากมีการชั่งสินค้าแล้ว");
                    }

                    //Delete All Receive
                    sql = @"DELETE FROM receives WHERE receive_no=@receive_no";
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

        //public static List<ReceiveItem> GetItems(string receiveNo)
        //{
        //    try
        //    {
        //        var receiveItems = new List<ReceiveItem>();
        //        using (var conn = new MySqlConnection(Globals.CONN_STR))
        //        {
        //            conn.Open();
        //            var sql = @"select a.order_no,
        //                        a.seq,
        //                        receive_qty,
        //                        receive_wgh,
        //                        b.product_name
        //                        from receive_item a,product b
        //                        where a.product_code =b.product_code
        //                        and receive_no =@receive_no
        //                        order by queue_no,seq asc";


        //            var cmd = new MySqlCommand(sql, conn);
        //            cmd.Parameters.AddWithValue("receive_no", receiveNo);
        //            var da = new MySqlDataAdapter(cmd);

        //            var ds = new DataSet();
        //            da.Fill(ds);

        //            foreach (DataRow item in ds.Tables[0].Rows)
        //            {
        //                receiveItems.Add(new ReceiveItem
        //                {
        //                    ReceiveNo = (string)item["receive_no"],
        //                    //QueueNo = (string)item["queue_no"],
        //                    Seq = (int)item["seq"],
        //                    //Product = new Product
        //                    //{
        //                    //    ProductCode = item["product_code"].ToString(),
        //                    //    ProductName = item["product_name"].ToString(),
        //                    //},
        //                    SexFlag = (string)item["sex_flag"],
        //                    ReceiveQty = (int)item["receive_qty"],
        //                    ReceiveWgh = (decimal)item["receive_wgh"],

        //                });
        //            }

        //        }

        //        return receiveItems;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static bool InsertItem(ReceiveItem receiveItem)
        //{
        //    var conn = new MySqlConnection(Globals.CONN_STR);
        //    MySqlTransaction transaction = null;
        //    try
        //    {

        //        conn.Open();

        //        Receive receive = GetReceive(receiveItem.ReceiveNo);
        //        var sql = @"SELECT max(seq) as seq,sum(receive_qty) as receive_qty
        //                        FROM receive_item 
        //                        WHERE receive_no=@receive_no
        //                        AND product_code=@product_code
        //                        GROUP BY receive_no,product_code";
        //        var cmd = new MySqlCommand(sql, conn);

        //        cmd.Parameters.AddWithValue("receive_no", receiveItem.ReceiveNo);
        //        cmd.Parameters.AddWithValue("product_code", receiveItem.ProductCode);
        //        var da = new MySqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        da.Fill(ds);

        //        var sumReceiveQty = 0;
        //        if (ds.Tables[0].Rows.Count == 0)
        //        {
        //            receiveItem.Seq = 1;
        //        }
        //        else
        //        {
        //            sumReceiveQty = ds.Tables[0].Rows[0]["receive_qty"].ToString().ToInt16();
        //            receiveItem.Seq += ds.Tables[0].Rows[0]["seq"].ToString().ToInt16() + 1;
        //        }
        //        var remainQty = receive.FactoryQty - sumReceiveQty;
        //        if (remainQty == 0)
        //        {
        //            throw new Exception("ไม่สามารถรับสินค้าได้ เนื่องจากรับสินค้าครบแล้ว!");
        //        }
        //        transaction = conn.BeginTransaction();

        //        sql = @"INSERT INTO receive_item(
        //                        receive_no,
        //                        product_code,
        //                        seq,
        //                        sex_flag,
        //                        receive_qty,
        //                        receive_wgh,
        //                        create_by)
        //                        VALUES(
        //                        @receive_no,
        //                        @product_code,
        //                        @seq,
        //                        @sex_flag,
        //                        @receive_qty,
        //                        @receive_wgh,
        //                        @create_by)";
        //        cmd = new MySqlCommand()
        //        {
        //            Connection = conn,
        //            CommandText = sql,
        //            Transaction = transaction
        //        };

        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("receive_no", receiveItem.ReceiveNo);
        //        cmd.Parameters.AddWithValue("product_code", receiveItem.ProductCode);
        //        cmd.Parameters.AddWithValue("seq", receiveItem.Seq);
        //        cmd.Parameters.AddWithValue("sex_flag", receiveItem.SexFlag);
        //        cmd.Parameters.AddWithValue("receive_qty", receiveItem.ReceiveQty);
        //        cmd.Parameters.AddWithValue("receive_wgh", receiveItem.ReceiveWgh);
        //        cmd.Parameters.AddWithValue("create_by", receiveItem.CreateBy);
        //        cmd.ExecuteNonQuery();


        //        if (receive.ReceiveFlag == 0)
        //        {
        //            //Update FactoryQty,FactoryWgh  เฉพาะการรับหมูเป็น
        //            sql = @"UPDATE receives SET 
        //                    factory_qty=factory_qty + @factory_qty,
        //                    factory_wgh=factory_wgh + @factory_wgh
        //                    WHERE receive_no=@receive_no";
        //            cmd.CommandText = sql;
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.AddWithValue("receive_no", receiveItem.ReceiveNo);
        //            cmd.Parameters.AddWithValue("factory_qty", receiveItem.ReceiveQty);
        //            cmd.Parameters.AddWithValue("factory_wgh", receiveItem.ReceiveWgh);
        //            cmd.ExecuteNonQuery();
        //        }

        //        //Insert Stock
        //        var plant = PlantController.GetPlant();
        //        var stockItemRunning = StockItemRunningController.GetStockItem(receiveItem.ReceiveNo);

        //        var stock = new Stock
        //        {
        //            StockDate = plant.ProductionDate,
        //            StockNo = stockItemRunning.StockNo,
        //            StockItem = stockItemRunning.StockItem,
        //            ProductCode = receiveItem.ProductCode,
        //            RefDocumentNo = receive.ReceiveNo,
        //            RefDocumentType = "REV",
        //            LotNo = DocumentGenerate.GetSwineLotNo(plant.PlantId, plant.ProductionDate, receive.QueueNo),
        //            StockQty = receive.FactoryQty,
        //            StockWgh = receive.FactoryWgh,
        //            BarcodeNo = 0,
        //            TransactionType = 1,
        //            LocationCode = 1,
        //            CreateBy = "system",
        //        };


        //        StockController.InsertStock(stock, cmd);
        //        // Commit the transaction.
        //        transaction.Commit();
        //        return true;



        //    }
        //    catch (Exception)
        //    {
        //        if (transaction != null)
        //            transaction.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }

        //}

        //public static bool ReceiveCarcass(Receive receive)
        //{
        //    var conn = new MySqlConnection(Globals.CONN_STR);
        //    MySqlTransaction transaction = null;
        //    try
        //    {

        //        conn.Open();


        //        var sql = @"SELECT max(seq) as seq,sum(receive_qty) as receive_qty
        //                        FROM receive_item 
        //                        WHERE receive_no=@receive_no
        //                        AND product_code=@product_code
        //                        GROUP BY receive_no,product_code";
        //        var cmd = new MySqlCommand(sql, conn);

        //        cmd.Parameters.AddWithValue("receive_no", receive.ReceiveNo);
        //        cmd.Parameters.AddWithValue("product_code", receive.ReceiveItems[0].ProductCode);
        //        var da = new MySqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        da.Fill(ds);

        //        var sumReceiveQty = 0;
        //        if (ds.Tables[0].Rows.Count == 0)
        //        {
        //            receive.ReceiveItems[0].Seq = 1;
        //        }
        //        else
        //        {
        //            sumReceiveQty = ds.Tables[0].Rows[0]["receive_qty"].ToString().ToInt16();
        //            receive.ReceiveItems[0].Seq += ds.Tables[0].Rows[0]["seq"].ToString().ToInt16() + 1;
        //        }
        //        var remainQty = receive.FactoryQty - sumReceiveQty;
        //        if (remainQty == 0)
        //        {
        //            throw new Exception("ไม่สามารถรับสินค้าได้ เนื่องจากรับสินค้าครบแล้ว!");
        //        }
        //        transaction = conn.BeginTransaction();
        //        cmd = new MySqlCommand()
        //        {
        //            Connection = conn,
        //            CommandText = sql,
        //            Transaction = transaction
        //        };

        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("receive_no", receive.ReceiveNo);
        //        cmd.Parameters.AddWithValue("product_code", receive.ReceiveItems[0].ProductCode);
        //        cmd.Parameters.AddWithValue("seq", receive.ReceiveItems[0].Seq);
        //        cmd.Parameters.AddWithValue("sex_flag", receive.ReceiveItems[0].SexFlag);
        //        cmd.Parameters.AddWithValue("receive_qty", receive.ReceiveItems[0].ReceiveQty);
        //        cmd.Parameters.AddWithValue("receive_wgh", receive.ReceiveItems[0].ReceiveWgh);
        //        cmd.Parameters.AddWithValue("create_by", receive.ReceiveItems[0].CreateBy);
        //        cmd.ExecuteNonQuery();



        //        //Insert Stock
        //        var plant = PlantController.GetPlant();
        //        var stockItemRunning = StockItemRunningController.GetStockItem(receive.ReceiveNo);

        //        var stock = new Stock
        //        {
        //            StockDate = plant.ProductionDate,
        //            StockNo = stockItemRunning.StockNo,
        //            StockItem = stockItemRunning.StockItem,
        //            ProductCode = receive.ReceiveItems[0].ProductCode,
        //            RefDocumentNo = receive.ReceiveNo,
        //            RefDocumentType = "REV",
        //            LotNo = DocumentGenerate.GetSwineLotNo(plant.PlantId, plant.ProductionDate, receive.QueueNo),
        //            StockQty = receive.FactoryQty,
        //            StockWgh = receive.FactoryWgh,
        //            BarcodeNo = 0,
        //            TransactionType = 1,
        //            LocationCode = 2,
        //            CreateBy = "system",
        //        };


        //        StockController.InsertStock(stock, cmd);
        //        // Commit the transaction.
        //        transaction.Commit();
        //        return true;



        //    }
        //    catch (Exception)
        //    {
        //        if (transaction != null)
        //            transaction.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }

        //}

        public static int GetReceiveFlag(string receiveNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();


                    var sql = @"select receive_flag from receives
                                WHERE receive_no=@receive_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("receive_no", receiveNo);
                    var receive_flag = cmd.ExecuteScalar();
                    return receive_flag.ToString().ToInt16();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


        public static bool CloseFlagSwineReceive(string receiveNo, string modifiedBy)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();


                    var sql = @"UPDATE receives SET
                                receive_flag=2,
                                modified_at=CURRENT_TIMESTAMP,
                                modified_by=@modified_by
                                WHERE receive_no=@receive_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("receive_no", receiveNo);
                    cmd.Parameters.AddWithValue("modified_by", modifiedBy);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static bool ReverseCloseFlagSwineReceive(string receiveNo)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"UPDATE receives SET
                                receive_flag=1,
                                modified_at=null,
                                modified_by=null
                                WHERE receive_no=@receive_no";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("receive_no", receiveNo);
                    cmd.ExecuteNonQuery();
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
