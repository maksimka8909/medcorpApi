using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class Preparation
    {
        public Preparation()
        {
            SupplyOfPreparations = new HashSet<SupplyOfPreparation>();
        }

        public int IdPreparation { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public int? IdProvider { get; set; }

        public virtual Provider IdProviderNavigation { get; set; }
        public virtual ICollection<SupplyOfPreparation> SupplyOfPreparations { get; set; }
    }
}
