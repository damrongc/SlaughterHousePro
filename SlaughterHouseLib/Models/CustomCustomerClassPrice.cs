using System;

namespace SlaughterHouseLib.Models
{
    public class CustomCustomerClassPrice
    {
        public int ClassId { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
