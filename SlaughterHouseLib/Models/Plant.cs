using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace SlaughterHouseLib.Models
{
    public class Plant
    {
        public int PlantId { get; set; }
        public DateTime ProductionDate { get; set; }
        public string PlantName { get; set; }
        public string Address { get; set; }
        public string EstNo { get; set; }
        public byte[] LogoImage { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public class PlantController
    {
        public static Plant GetPlant()
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT 
                                    p.plant_id,
                                    p.production_date,
                                    p.plant_name,
                                    p.address,
                                    p.est_no,
                                    p.logo_image,
                                    p.active,
                                    p.create_at,
                                    p.create_by,
                                    p.modified_at,
                                    p.modified_by
                                FROM plant p ";
                    //sb.Append(" where plant_id = @plant_id");

                    var cmd = new MySqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("plant_id", plantId);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    return new Plant
                    {
                        PlantId = (int)ds.Tables[0].Rows[0]["plant_id"],
                        ProductionDate = (DateTime)ds.Tables[0].Rows[0]["production_date"],
                        PlantName = (string)ds.Tables[0].Rows[0]["plant_name"],
                        Address = ds.Tables[0].Rows[0]["address"] == DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["address"],
                        EstNo = ds.Tables[0].Rows[0]["est_no"] == DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["est_no"],
                        LogoImage = ds.Tables[0].Rows[0]["logo_image"] == DBNull.Value ? null : (byte[])ds.Tables[0].Rows[0]["logo_image"],
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static object GetAllPlants()
        {
            try
            {

                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @"SELECT 
                                    p.plant_id,
                                    p.production_date,
                                    p.plant_name,
                                    p.address,
                                    p.est_no,
                                    p.logo_image,
                                    p.active,
                                    p.create_at,
                                    p.create_by,
                                    p.modified_at,
                                    p.modified_by
                                FROM plant p ";
                    //sb.Append(" where plant_id = @plant_id");

                    var cmd = new MySqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("plant_id", plantId);
                    var da = new MySqlDataAdapter(cmd);

                    var ds = new DataSet();
                    da.Fill(ds);

                    var coll = (from p in ds.Tables[0].AsEnumerable()
                                select new
                                {
                                    PlantId = p.Field<int>("plant_id"),
                                    ProductionDate = p.Field<DateTime>("production_date"),
                                    PlantName = p.Field<string>("plant_name"),
                                    Address = p.Field<string>("address"),
                                    EstNo = p.Field<string>("est_no"),
                                    LogoImage = p.Field<byte[]>("logo_image"),
                                    Active = p.Field<bool>("active"),
                                    CreateAt = p.Field<DateTime>("create_at"),
                                    CreateBy = p.Field<string>("create_by"),
                                    ModifiedAt = p.Field<DateTime?>("modified_at") != null ? p.Field<DateTime?>("modified_at") : null,
                                    ModifiedBy = p.Field<string>("modified_by") != "" ? p.Field<string>("modified_by") : "",
                                }).ToList();

                    return coll;

                }
            }
            catch (Exception )
            {

                throw;
            }
        }

        public static bool Update(Plant plant)
        {
            try
            {
                using (var conn = new MySqlConnection(Globals.CONN_STR))
                {
                    conn.Open();
                    var sql = @" UPDATE plant
                                 SET plant_name=@plant_name,
                                    address=@address,
                                    est_no=@est_no, ";
                    if (plant.LogoImage != null)
                    {
                        sql += @" logo_image =@logo_image, ";
                    }
                    sql += @" active =@active,
                                    modified_at=CURRENT_TIMESTAMP,
                                    modified_by=@modified_by
                                WHERE plant_id=@plant_id ";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("plant_id", plant.PlantId);
                    cmd.Parameters.AddWithValue("address", plant.Address);
                    cmd.Parameters.AddWithValue("plant_name", plant.PlantName);
                    cmd.Parameters.AddWithValue("est_no", plant.EstNo);
                    if (plant.LogoImage != null)
                    {
                        cmd.Parameters.AddWithValue("logo_image", plant.LogoImage);
                    }
                    cmd.Parameters.AddWithValue("active", plant.Active);
                    cmd.Parameters.AddWithValue("modified_by", plant.ModifiedBy);
                    var affRow = cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception )
            {
                throw;
            }
        }

        //public static bool Insert(Plant plant)
        //{
        //    try
        //    {

        //        using (var conn = new MySqlConnection(Globals.CONN_STR))
        //        {
        //            conn.Open();
        //            var sql = @"INSERT INTO plant
        //                        (production_date,
        //                        plant_name,
        //                        address,
        //                        est_no,
        //                        active,
        //                        create_by)
        //                        VALUES(@production_date,
        //                        @plant_name,
        //                        @address,
        //                        @est_no,
        //                        @active,
        //                        @create_by)";
        //            var cmd = new MySqlCommand(sql, conn);
        //            cmd.Parameters.AddWithValue("production_date", plant.ProductionDate);
        //            cmd.Parameters.AddWithValue("plant_name", plant.PlantName);
        //            cmd.Parameters.AddWithValue("est_no", plant.EstNo);
        //            cmd.Parameters.AddWithValue("plant_name", plant.PlantName);
        //            cmd.Parameters.AddWithValue("active", plant.Active);
        //            cmd.Parameters.AddWithValue("create_by", plant.CreateBy);
        //            var affRow = cmd.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public static bool Update(Plant plant)
        //{
        //    try
        //    {
        //        using (var conn = new MySqlConnection(Globals.CONN_STR))
        //        {
        //            conn.Open();
        //            var sql = @"UPDATE plant
        //                        SET production_date=@production_date,
        //                        plant_name=@plant_name,
        //                        address=@address,
        //                        est_no=@est_no,
        //                        active=@active,
        //                        modified_at=CURRENT_TIMESTAMP,
        //                        modified_by=@modified_by
        //                        WHERE plant_id=@plant_id";
        //            var cmd = new MySqlCommand(sql, conn);
        //            cmd.Parameters.AddWithValue("production_date", plant.ProductionDate);
        //            cmd.Parameters.AddWithValue("plant_name", plant.PlantName);
        //            cmd.Parameters.AddWithValue("est_no", plant.EstNo);
        //            cmd.Parameters.AddWithValue("plant_name", plant.PlantName);
        //            cmd.Parameters.AddWithValue("active", plant.Active);
        //            cmd.Parameters.AddWithValue("modified_by", plant.ModifiedBy);
        //            var affRow = cmd.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
