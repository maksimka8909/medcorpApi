using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class SupplySheetOfEquipment
    {
        public int IdSheet { get; set; }
        public DateTime DateOfSupply { get; set; }
        public int? IdProvider { get; set; }
        public int? IdSupply { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Provider IdProviderNavigation { get; set; }
        public virtual SupplyOfEquipment IdSupplyNavigation { get; set; }
    }
}
