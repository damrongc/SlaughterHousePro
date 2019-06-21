using System;

namespace SlaughterHouseLib.Models
{
    public class Unit
    {
        public int UnitCode { get; set; }
        public string UnitName { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

    }


}
