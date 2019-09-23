using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace SlaughterHouseLib.Models
{
    public class Bom
    {
        public int BomCode { get; set; }
        public Product Product { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<BomItem> BomItems { get; set; }

    }
    public class BomItem
    {
        public int BomCode { get; set; }
        public Product Product { get; set; }
        public int MutiplyQty { get; set; }
        public decimal MutiplyWgh { get; set; }
    }

}
