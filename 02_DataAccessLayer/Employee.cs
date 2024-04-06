using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccessLayer
{
    public class Employee
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public DateTime HireDate { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{Id,3} {Fullname,-25} {HireDate} {Gender} {Salary}";
        }
    }
}
