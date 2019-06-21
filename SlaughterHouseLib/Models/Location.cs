using System;

namespace SlaughterHouseLib.Models
{
    public class Location
    {
        public int LocationCode { get; set; }
        public string LocationName { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

    }


}
