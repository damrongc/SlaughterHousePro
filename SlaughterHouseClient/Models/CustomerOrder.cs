using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaughterHouseClient.Models
{
    public class CustomerOrder
    {
        public string order_no { get; set; }
        public DateTime order_date { get; set; }
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public string address { get; set; }

        public string comments { get; set; }
    }
}
