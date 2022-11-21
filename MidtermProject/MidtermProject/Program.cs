using MidtermProject;

ProductFile productFile = new ProductFile();


DisplayFoodMenu();
Console.WriteLine();
Console.WriteLine();

DisplayDrinkMenu();
Console.WriteLine();
Console.WriteLine();

DisplayMerchMenu();
Console.WriteLine();
Console.WriteLine();

void WelcomeCustomer()
{

}

void DisplayMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    foreach (Product p in productFile.products)
    {
        Console.WriteLine($"{p.Name.PadRight(40, '.')}{p.Price.ToString().PadLeft(6, '.'):C2}");
    }
}

void DisplayFoodMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine("FOOD");
    Console.WriteLine($"".PadRight(46, '*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Food"))
    {
        Console.WriteLine($"{p.Name.PadRight(40, '.')}{p.Price.ToString().PadLeft(6, '.'):C2}");
    }
}

void DisplayDrinkMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine("DRINKS");
    Console.WriteLine($"".PadRight(46,'*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Drink"))
    {
        Console.WriteLine($"{p.Name.PadRight(40, '.')}{p.Price.ToString().PadLeft(6, '.'):C2}");
    }
}

void DisplayMerchMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine("MERCH/SWAG");
    Console.WriteLine($"".PadRight(46,'*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Merchandise"))
    {
        Console.WriteLine($"{p.Name.PadRight(40, '.')}{p.Price.ToString().PadLeft(6, '.'):C2}");
    }
}

void DisplayBill()
{

}

void PrintReceipt(List<string> foodOrder, List<string> drinkOrder, List<string> merchOrder, int total, int taxAndPrice)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("         GOOD TIME BREWERY & EATS        ");
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Item", "Price"));
    Console.WriteLine("-----------------------------------------\n");

    Console.WriteLine("FOOD");
    Console.WriteLine("-----------------------------------------");

    foreach (string food in foodOrder)
    {
        Console.WriteLine(string.Format("{0,-30} {1, 10}",
        food, "$" + food.Price));
    }

    Console.WriteLine("\nDRINKS");
    Console.WriteLine("-----------------------------------------");

    foreach (string drink in drinkOrder)
    {
        Console.WriteLine(string.Format("{0,-30} {1, 10}",
            drink, "$" + drink.Price));
    }

    Console.WriteLine("\nMERCHANDISE");
    Console.WriteLine("-----------------------------------------");

    foreach (string merch in merchOrder)
    {
        Console.WriteLine(string.Format("{0,-30} {1, 10}",
            merch, "$" + merch.Price));
    }

    Console.WriteLine("\n-----------------------------------------");
    Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Subtotal", "$" + Payment.Total());
    Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Tax (6%)", "$" + Payment.Tax());
    Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Total Bill", "$" + Payment.CalculateGrandTotal(total, taxAndPrice));
    Console.WriteLine("-----------------------------------------");
}

void AddToOrder(Product prod)
{
    
}

PaymentOptions AskPaymentType()
{
    // if... return PaymentOptions.CreditCard

    // if... return PaymentOptions.Cash

    // if... return PaymentOptions.Check

    return PaymentOptions.Cash;
}

