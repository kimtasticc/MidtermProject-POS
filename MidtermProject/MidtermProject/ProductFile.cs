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
            //string fileName = "Product.txt";
            string fileName = @"\.\MidtermProject\Product.txt";
            string line = "";
            string[] values;
            StreamReader reader = new StreamReader(fileName);

            while (true)
            {
                line = reader.ReadLine();
                if (line == null) { break; }
                values = line.Split('|');
                items.Add(new Product() { Name = values[0], Description = values[1], Price = values[2] });
            }

            reader.Close();
            return items;
        }
    }
}
