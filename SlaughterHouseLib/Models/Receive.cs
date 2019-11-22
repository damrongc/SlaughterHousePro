using System;
using System.Collections.Generic;

namespace SlaughterHouseLib.Models
{
    public class Receive
    {
        public string ReceiveNo { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string TransportDocNo { get; set; }
        public Truck Truck { get; set; }
        public Farm Farm { get; set; }
        public string CoopNo { get; set; }

        public Breeder Breeder { get; set; }

        public int QueueNo { get; set; }
        public string LotNo { get; set; }
        public int FarmQty { get; set; }
        public decimal FarmWgh { get; set; }

        public int FactoryQty { get; set; }
        public decimal FactoryWgh { get; set; }
        public int ReceiveFlag { get; set; }

        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public List<ReceiveItem> ReceiveItems { get; set; }
    }


}
