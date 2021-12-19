using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class EmployeeView
    {
        public int IdEmployee { get; set; }
        public int IdLaborContract { get; set; }
        public int IdPersonalFile { get; set; }
        public bool Status { get; set; }
        public int IdUser { get; set; }

        public EmployeeView()
        {

        }

    }
}
