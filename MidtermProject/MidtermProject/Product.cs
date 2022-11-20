using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public Product(string name, string description, double price, string type)
        {
            Name = name;
            Description = description;
            Price = price;
            Type = type;
        }
    }
}



