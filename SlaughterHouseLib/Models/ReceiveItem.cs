using System;

namespace SlaughterHouseLib.Models
{
    public class ReceiveItem
    {
        public string ReceiveNo { get; set; }
        //public string QueueNo { get; set; }
        public int Seq { get; set; }
        //public Product Product { get; set; }
        public string SexFlag { get; set; }
        public int ReceiveQty { get; set; }
        public decimal ReceiveWgh { get; set; }


        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }


}
