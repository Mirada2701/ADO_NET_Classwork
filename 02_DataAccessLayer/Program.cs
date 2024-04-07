using _04_data_access.Models;
using _04_data_access;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace _02_DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.UTF8;
            //SportShopDB dB = new SportShopDB("LEGION5\\SQLEXPRESS", "SportShop");

            //Console.WriteLine("Enter product name to search : ");
            //string name = Console.ReadLine();

            //List<Product> products = dB.GetAllByName(name);
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"{item.Id,5} {item.Name,-20}{item.Price,10}");
            //}            


            /*
            Product product = new Product()
            { 
            Name = "Bottle XL",
            Type = "Equipment",
            Quantity = 25,
            CostPrice=450,
            Producer = "Poland",
            Price = 600
            };
            //dB.Create(product);
            //dB.Delete(8);

            
            Product pr = dB.GetOneProduct(1);
            Console.WriteLine($"{pr.Id,5} {pr.Name,-20}{pr.Price,10} {pr.CostPrice,10}");
            pr.CostPrice -= 50;
            pr.Price -= 50;
            Console.WriteLine($"{pr.Id,5} {pr.Name,-20}{pr.Price,10} {pr.CostPrice,10}");

            dB.Update(pr);
            
            //----------------------------------HW---------------------------------------------
            //Sale sale = new Sale()
            //{ 
            //ProductId = 3,
            //Price = 1400,
            //Quantity=2,
            //EmployeeId = 2,
            //ClientId = 2,
            //SaleDate = DateTime.Now,
            //};
            ////dB.AddNewSalles(sale);

            //foreach(var item in dB.GetAllSalles())
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("-------------------------------------------\n");
            //Sale s = dB.GetLastSaleClient("Петрук Степан Романович");
            //Console.WriteLine(s);

            //Console.WriteLine("-------------------------------------------\n");
            //Employee e = dB.GetMostSaleEmployee();
            //Console.WriteLine(e);
            */
        }
    }
}
