using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class UserView
    {
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
        public bool Status { get; set; }
        public DateTime UpdateTime { get; set; }

        public UserView()
        {

        }
    }
}
