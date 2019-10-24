using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaughterHouseClient.Models
{
    public class CustomerTransport
    {

        public string transport_no { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public int seq { get; set; }
        public int transport_qty { get; set; }
        public decimal transport_wgh { get; set; }
        public string stock_no { get; set; }
        public string lot_no { get; set; }
        public string truck_no { get; set; }
        public long barcode_no { get; set; }
        public int bom_code { get; set; }
        public DateTime create_at { get; set; }
    }
}
