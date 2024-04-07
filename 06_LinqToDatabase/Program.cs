using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_LinqToDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext contex = new DataClasses1DataContext();
            foreach(var item in contex.Products)
            {
                Console.WriteLine($"{item.Name}, {item.CostPrice}, {item.Producer}");
            }
            foreach (var item in contex.Salles)
            {
                Console.WriteLine($"{item.ClientId}, {item.EmployeeId}, {item.Price}");
            }
        }
    }
}
