using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAPI.Models
{
    public partial class Post
    {
        public Post()
        {
            LaborContracts = new HashSet<LaborContract>();
        }

        public int IdPost { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<LaborContract> LaborContracts { get; set; }
    }
}
