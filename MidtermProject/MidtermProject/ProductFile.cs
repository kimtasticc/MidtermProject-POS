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
            string fileName = "C:\\MidTerm\\Product.txt";
            //string fileName = @".\MidtermProject\MidtermProject\Product.txt";
            //string fileName = @"\Users\John.Poston\source\repos\MidtermProjectPOS\MidtermProject\MidtermProject\Product.txt";
            //string fileName = @"C:\Users\John.Poston\source\repos\MidtermProjectPOS\MidtermProject\MidtermProject\Product.txt";
            string line = "";
            string[] values;
            StreamReader reader = new StreamReader(fileName);
            List<Product> items = new List<Product>();
            while (true)
            {
                line = reader.ReadLine();
                if (line == null) { break; }
                values = line.Split('|');
                int id = int.Parse(values[0]);
                string name = values[1];
                string desc = values[2];
                string price = values[3];
                double dblPrice = 0;
                double.TryParse(price, out dblPrice);
                string type = values[4];
                items.Add(new Product(id, name, desc, dblPrice, type));
            }

            reader.Close();
            return items;
        }
    }
}
