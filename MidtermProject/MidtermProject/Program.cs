using MidtermProject;

ProductFile productFile = new ProductFile();
//Dictionary<int, Product> productList = new Dictionary<int, Product>();

int mainMenuSelection = 0;
int[] mainMenuOptions = new int[2] { 1, 2 };
int mainMenuCounter = 0;

while (!mainMenuOptions.Contains(mainMenuSelection))
{
    mainMenuCounter++;
    if(mainMenuCounter > 1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.WriteLine("Invalid selection. Please choose an option from the menu.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    DisplayMainMenu();
    mainMenuSelection = GetMainMenuSelection();
    if(mainMenuSelection == 1)
    {
        mainMenuCounter = 0;
        DisplayOrderMenu();
    }
    else if (mainMenuSelection == 2)
    {
        mainMenuCounter = 0;
    }
}

void DisplayMainMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine($"Microbrewery Point of Sale System");
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine($"Enter 1 to start a new order.");
    Console.WriteLine($"Enter 2 to Exit.");    
}

int GetMainMenuSelection()
{
    int selection = 0;
    int.TryParse(Console.ReadLine(), out selection);
    return selection;
}


void DisplayOrderMenu()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine($"Order entry system");
    Console.WriteLine($"".PadRight(46, '*'));
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine($"Enter 1 to add Food to order.");
    Console.WriteLine($"Enter 2 to add Drink to order.");
    Console.WriteLine($"Enter 3 to add Merchandise to order.");
    Console.WriteLine($"Enter 4 to cashout.");
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
    Console.WriteLine("MERCHANDISE");
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

