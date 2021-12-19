using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class SupplyOfEquipment
    {
        public SupplyOfEquipment()
        {
            SupplySheetOfEquipments = new HashSet<SupplySheetOfEquipment>();
        }

        public int IdSupply { get; set; }
        public int Number { get; set; }
        public int? IdEquipment { get; set; }

        public virtual Equipment IdEquipmentNavigation { get; set; }
        public virtual ICollection<SupplySheetOfEquipment> SupplySheetOfEquipments { get; set; }
    }
}
