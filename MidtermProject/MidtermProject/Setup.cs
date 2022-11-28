using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    public static class Setup
    {
        private static DirectoryInfo productDirectory { get; set; }
        public static FileInfo productFile { get; set; }

        public static void Run()
        {
            SetupProductDirectory();
            SetupProductFile();
            if(productFile.Length == 0) { InitializeProductFile(); }
        }
        private static void SetupProductDirectory() 
        {
            productDirectory = new DirectoryInfo(@"C:\MidTerm");
            if (productDirectory.Exists == true)
            {
                
            }
            else if(productDirectory.Exists == false)
            {
                productDirectory.Create();
            }
        } 

        private static void SetupProductFile()
        {
            productFile = new FileInfo(productDirectory.FullName + "\\Product.txt");
            if(productFile.Exists == true)
            {

            }
            else if(productFile.Exists == false)
            {
                productFile.Create().Dispose();
            }
        }
        private static void InitializeProductFile()
        {
            StreamWriter sw = new StreamWriter(productFile.FullName);
            sw.WriteLine("101|Two Hearted Ale IPA|An American IPA brewed and dry hopped with 100% Centennial hops.|6.00|Drink");
            sw.WriteLine("102|Siren Amber Ale|An American Amber / Red Ale style beer brewed by North Peak Brewing Company.|5.50|Drink");
            sw.WriteLine("103|PBR|Pabst Blue Ribbon|3.75|Drink");
            sw.WriteLine("104|Imperial Apple Hard Cider|Tastes kind of like apples.|6.00|Drink");
            sw.WriteLine("105|Pink Lemonade Hard Seltzer|Real fruity flavor.|5.00|Drink");
            sw.WriteLine("106|Classic Manhattan|Two parts whiskey, one part sweet vermouth and bitters.|12.50|Drink");
            sw.WriteLine("201|Giant Soft Pretzel with Beer Cheese|A match made in heaven.|8.95|Food");
            sw.WriteLine("202|Nacho Supreme|Nachos, beef, tomatoes, sour cream and cheese|13.50|Food");
            sw.WriteLine("301|Long Sleeve Logo Tee|Description|25.00|Merchandise");
            sw.WriteLine("302|Logo Hoodie|Description|35.00|Merchandise");
            sw.WriteLine("303|Beer Koozie 4pk|Description|10.00|Merchandise");
            sw.WriteLine("304|16oz Pint Glass|Description|21.99|Merchandise");
            sw.Close();
        }
    }
}
