using MidtermProject;

ProductFile productFile = new ProductFile();
//Dictionary<int, Product> productList = new Dictionary<int, Product>();
Order order = new Order();

int mainMenuSelection = 0;
int[] mainMenuOptions = new int[2] { 1, 2 };
int mainMenuCounter = 0;

int orderMenuSelection = 0;
int orderMenuCounter = 0;
int[] orderMenuOptions = new int[4] { 1, 2, 3, 4 };


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
        
        while (true)
        {
            DisplayOrderMenu();
            orderMenuSelection = GetOrderMenuSelection();
            if (orderMenuSelection == 1)
            {
                DisplayFoodMenu();
                int foodMenuSelection = 0;
                while (!productFile.products.Exists(x => x.ID == foodMenuSelection))
                {
                    foodMenuSelection = GetFoodMenuSelection(); // validate this is a valid Product ID
                }
                Console.WriteLine("Please enter Qty");
                int qty = 0;
                int.TryParse(Console.ReadLine(), out qty);
                Product product = productFile.products.Where(x => x.ID == foodMenuSelection).FirstOrDefault();
                OrderLine orderLine = new OrderLine(product, qty);
                order.OrderLines.Add(orderLine);
            }
            else if (orderMenuSelection == 2)
            {
                DisplayDrinkMenu();
            }
            else if (orderMenuSelection == 3)
            {
                DisplayMerchMenu();
            }
            else if (orderMenuSelection == 4)
            {
                PaymentOptions paymentMethod = GetPaymentMethod(); // need validation
                Payment payment;

                switch (paymentMethod)
                {
                    case PaymentOptions.CreditCard:
                        Console.WriteLine("Enter Credit Card Number:");
                        string ccNum = Console.ReadLine();
                        Console.WriteLine("Enter Expiration Date");
                        string expDate = Console.ReadLine();
                        Console.WriteLine("Enter CVV");
                        int cvv = 0;
                        int.TryParse(Console.ReadLine(), out cvv);
                        payment = new Payment(ccNum, cvv, DateOnly.Parse(expDate)); // need actual values from program
                        break;

                    case PaymentOptions.Cash:
                        Console.WriteLine("Enter cash tendered:");
                        double cashTendered = 0;
                        double.TryParse(Console.ReadLine(), out cashTendered);
                        payment = new Payment(cashTendered); // need actual values from program
                        break;

                    case PaymentOptions.Check:
                        long checkNum = 0;
                        long acctNum = 0;
                        long routeNum = 0;
                        Int64.TryParse(Console.ReadLine(), out checkNum);
                        Int64.TryParse(Console.ReadLine(), out acctNum);
                        Int64.TryParse(Console.ReadLine(), out routeNum);
                        payment = new Payment(checkNum, acctNum, routeNum); // need actual values from program
                        break;
                }
                DisplayBill();
                break;
            }
        }      
     
    }
    else if (mainMenuSelection == 2)
    {
        mainMenuCounter = 0;
    }
}

void DisplayMainMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine($"Good Times Brewery & Eats");
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

PaymentOptions GetPaymentMethod()
{
    int paymentMethod = 0;
    Console.WriteLine("Choose from this list:");
    Console.WriteLine("1 Credit Card");
    Console.WriteLine("2 Cash");
    Console.WriteLine("3 Check");
    // needs to be 1, 2, or 3
    int.TryParse(Console.ReadLine(), out paymentMethod);
    PaymentOptions paymentOptions = new PaymentOptions();
    if(paymentMethod == 1)
    {
        paymentOptions = PaymentOptions.CreditCard;
    }
    else if (paymentMethod == 2)
    {
        paymentOptions = PaymentOptions.Cash;
    }
    else if (paymentMethod == 3)
    {
        paymentOptions = PaymentOptions.Check;
    }
    return paymentOptions;
}

int GetOrderMenuSelection()
{
    int selection = 0;
    int.TryParse(Console.ReadLine(), out selection);
    return selection;
}

void DisplayFoodMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine("FOOD");
    Console.WriteLine($"".PadRight(46, '*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Food"))
    {
        Console.WriteLine($"{p.ID} {p.Name.PadRight(40, '.')}{p.Price.ToString().PadLeft(6, '.'):C2}");
    }
}

int GetFoodMenuSelection()
{
    int selection = 0;
    int.TryParse(Console.ReadLine(), out selection);
    return selection;
}

void DisplayDrinkMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine("DRINKS");
    Console.WriteLine($"".PadRight(46,'*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Drink"))
    {
        Console.WriteLine($"{p.ID} {p.Name.PadRight(40, '.')}{p.Price.ToString().PadLeft(6, '.'):C2}");
    }
}

int GetDrinkMenuSelection()
{
    int selection = 0;
    int.TryParse(Console.ReadLine(), out selection);
    return selection;
}

void DisplayMerchMenu()
{
    Console.WriteLine($"".PadRight(46, '*'));
    Console.WriteLine("MERCHANDISE");
    Console.WriteLine($"".PadRight(46,'*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Merchandise"))
    {
        Console.WriteLine($"{p.ID} {p.Name.PadRight(40, '.')}{p.Price.ToString().PadLeft(6, '.'):C2}");
    }
}

int GetMerchMenuSelection()
{
    int selection = 0;
    int.TryParse(Console.ReadLine(), out selection);
    return selection;
}

void DisplayBill()
{
    double subtotal = 0;
    double tax = 0;
    const double taxRate = 0.06;
    double total = 0;
    subtotal = order.OrderLines.Sum(x => x.ExtPrice);
    tax =  //subtotal * taxRate;
    total = subtotal + tax;

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("         GOOD TIME BREWERY & EATS        ");
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Item", "Price"));
    Console.WriteLine("-----------------------------------------\n");

    Console.WriteLine("FOOD");
    Console.WriteLine("-----------------------------------------");

    //foreach (string food in foodOrder)
    //{
        //Console.WriteLine(string.Format("{0,-30} {1, 10}",
        //food, "$" + food.Price));
    //}

    Console.WriteLine("\nDRINKS");
    Console.WriteLine("-----------------------------------------");

    //foreach (string drink in drinkOrder)
    //{
        //Console.WriteLine(string.Format("{0,-30} {1, 10}",
        //    drink, "$" + drink.Price));
    //}

    Console.WriteLine("\nMERCHANDISE");
    Console.WriteLine("-----------------------------------------");

    //foreach (string merch in merchOrder)
    //{
        //Console.WriteLine(string.Format("{0,-30} {1, 10}",
        //merch, "$" + merch.Price));
    //}

    Console.WriteLine("\n-----------------------------------------");
    //Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Subtotal", "$" + Payment.Total());
    //Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Tax (6%)", "$" + Payment.Tax());
    //Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Total Bill", "$" + Payment.CalculateGrandTotal(total, taxAndPrice));
    Console.WriteLine("-----------------------------------------");
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
        //Console.WriteLine(string.Format("{0,-30} {1, 10}",
        //food, "$" + food.Price));
    }

    Console.WriteLine("\nDRINKS");
    Console.WriteLine("-----------------------------------------");

    foreach (string drink in drinkOrder)
    {
        //Console.WriteLine(string.Format("{0,-30} {1, 10}",
        //    drink, "$" + drink.Price));
    }

    Console.WriteLine("\nMERCHANDISE");
    Console.WriteLine("-----------------------------------------");

    foreach (string merch in merchOrder)
    {
        //Console.WriteLine(string.Format("{0,-30} {1, 10}",
        //merch, "$" + merch.Price));
    }

    Console.WriteLine("\n-----------------------------------------");
    //Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Subtotal", "$" + Payment.Total());
    //Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Tax (6%)", "$" + Payment.Tax());
    //Console.WriteLine(string.Format("{0,-33} | {1, 05}", "Total Bill", "$" + Payment.CalculateGrandTotal(total, taxAndPrice));
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

