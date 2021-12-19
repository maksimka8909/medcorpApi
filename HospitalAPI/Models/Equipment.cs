using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            SupplyOfEquipments = new HashSet<SupplyOfEquipment>();
        }

        public int IdEquipment { get; set; }
        public string Name { get; set; }
        public int? IdTypeOfEquipment { get; set; }
        public string Manufacturer { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }

        public virtual TypeOfEqupiment IdTypeOfEquipmentNavigation { get; set; }
        public virtual ICollection<SupplyOfEquipment> SupplyOfEquipments { get; set; }
    }
}
