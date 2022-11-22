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
        Console.WriteLine($"{p.Name.PadRight(40, '.')}{p.Price.ToString("C").PadLeft(6, '.'):C2}");
    }
}

void DisplayDrinkMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine("DRINKS");
    Console.WriteLine($"".PadRight(46,'*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Drink"))
    {
        Console.WriteLine($"{p.Name.PadRight(40, '.')}{p.Price.ToString("C").PadLeft(6, '.'):C2}");
    }
}

void DisplayMerchMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine("MERCH/SWAG");
    Console.WriteLine($"".PadRight(46,'*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Merchandise"))
    {
        Console.WriteLine($"{p.Name.PadRight(40, '.')}{p.Price.ToString("C").PadLeft(6, '.'):C2}");
    }
}

void DisplayBill()
{

}

void PrintReceipt()
{

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

