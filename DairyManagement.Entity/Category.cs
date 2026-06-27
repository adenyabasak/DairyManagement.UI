using System;
using System.Collections.Generic;
using System.Text;
namespace DairyManagement.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}