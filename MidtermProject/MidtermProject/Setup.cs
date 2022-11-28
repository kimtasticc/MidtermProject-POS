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
            sw.WriteLine("101|Two Hearted Ale IPA|American IPA brewed with 100% Centennial hops|6.00|Drink");
            sw.WriteLine("102|Siren Amber Ale|American Amber/Red Ale by North Peak Brewing Company|5.50|Drink");
            sw.WriteLine("103|PBR|Pabst Blue Ribbon|3.75|Drink");
            sw.WriteLine("104|Imperial Apple Hard Cider|Tastes kind of like apples|6.00|Drink");
            sw.WriteLine("105|Pink Lemonade Hard Seltzer|Real fruity flavor|5.00|Drink");
            sw.WriteLine("106|Classic Manhattan|Two parts whiskey, one part sweet vermouth and bitters|12.50|Drink");
            sw.WriteLine("201|Giant Soft Pretzel & Beer Cheese|A match made in heaven|8.95|Food");
            sw.WriteLine("202|Nacho Supreme|Nachos, beef, tomatoes, sour cream, and cheese|13.50|Food");
            sw.WriteLine("203|Burger & Fries|1/2lb grass-fed beef, L.T.O., with fries|13.99|Food");
            sw.WriteLine("204|Cheese Burger & Fries|1/2lb grass-fed beef, L.T.O., American Cheese with fries|16.99|Food");
            sw.WriteLine("205|Fish & Chips|Wild caught cod battered & fried to perfection with fries|12.99|Food");
            sw.WriteLine("301|Long Sleeve Logo Tee|Your friends will be jealous!|25.00|Merchandise");
            sw.WriteLine("302|Logo Hoodie|You know you want one!|35.00|Merchandise");
            sw.WriteLine("303|Beer Koozie 4pk|Better keep em cold!|10.00|Merchandise");
            sw.WriteLine("304|16oz Pint Glass|Anything tastes better in our glassware!|21.99|Merchandise");
            sw.Close();
        }
    }
}
