using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Preparations = new HashSet<Preparation>();
            SupplySheetOfEquipments = new HashSet<SupplySheetOfEquipment>();
            SupplySheetOfPreparations = new HashSet<SupplySheetOfPreparation>();
        }

        public int IdProvider { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Preparation> Preparations { get; set; }
        public virtual ICollection<SupplySheetOfEquipment> SupplySheetOfEquipments { get; set; }
        public virtual ICollection<SupplySheetOfPreparation> SupplySheetOfPreparations { get; set; }
    }
}
