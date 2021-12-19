using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Classes
{
    public class PostView
    {
        public int IdPost { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public PostView(int idPost, string name, decimal salary)
        {
            IdPost = idPost;
            Name = name;
            Salary = salary;
        }

        public PostView(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public PostView()
        {

        }
    }
}
