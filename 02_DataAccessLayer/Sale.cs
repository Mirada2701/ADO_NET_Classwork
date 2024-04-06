using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccessLayer
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public DateTime SaleDate { get; set; }
        public override string ToString()
        {
            return $"{Id} {ProductId} {Price} {Quantity} {EmployeeId} {ClientId} {SaleDate}";
        }
    }
}
