using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    public class ProductFile
    {
        public List<Product> products { get; set; }
        public ProductFile()
        {
            products = new List<Product>();
            products.AddRange(GetAllProducts());
        }
        List<Product> GetAllProducts()
        {
            string fileName = "Product.txt";
            //string fileName = @"\.\MidtermProject\Product.txt";
            string line = "";
            string[] values;
            StreamReader reader = new StreamReader(fileName);
            List<Product> items = new List<Product>();
            while (true)
            {
                line = reader.ReadLine();
                if (line == null) { break; }
                values = line.Split('|');
                string name = values[0];
                string desc = values[1];
                string price = values[2];
                double dblPrice = 0;
                double.TryParse(price, out dblPrice);
                string type = values[3];
                items.Add(new Product(name, desc, dblPrice, type));
            }

            reader.Close();
            return items;
        }
    }
}
