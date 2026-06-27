using System;
using System.Collections.Generic;
using System.Text;
namespace DairyManagement.Entity
{
    public class CustomerOrder
    {
        public int CustomerOrderId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}