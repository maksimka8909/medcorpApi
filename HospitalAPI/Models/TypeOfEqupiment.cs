using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class TypeOfEqupiment
    {
        public TypeOfEqupiment()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int IdTypeOfEquipment { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
