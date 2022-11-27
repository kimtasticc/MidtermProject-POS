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
        List<OrderLine> foodOrder = new List<OrderLine>();
        List<OrderLine> drinkOrder = new List<OrderLine>();
        List<OrderLine> merchOrder = new List<OrderLine>();

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
                foodOrder.Add(orderLine);
            }
            else if (orderMenuSelection == 2)
            {
                DisplayDrinkMenu();
                int drinkMenuSelection = 0;
                while(!productFile.products.Exists(x => x.ID == drinkMenuSelection))
                {
                    drinkMenuSelection = GetDrinkMenuSelection();
                }
                Console.WriteLine("Please enter Qty");
                int drinkQty = 0;
                int.TryParse(Console.ReadLine(), out drinkQty);
                Product product = productFile.products.Where(x => x.ID == drinkMenuSelection).FirstOrDefault();
                OrderLine orderLine = new OrderLine(product, drinkQty);
                order.OrderLines.Add(orderLine);
            }
            else if (orderMenuSelection == 3)
            {
                DisplayMerchMenu();
                int merchMenuSelection = 0;
                while(productFile.products.Exists(x => x.ID == merchMenuSelection))
                {
                    merchMenuSelection = GetMerchMenuSelection();
                }
                Console.WriteLine("Please enter Qty");
                int merchQty = 0;
                int.TryParse(Console.ReadLine(), out merchQty);
                Product product = productFile.products.Where(x => x.ID == merchMenuSelection).FirstOrDefault();
                OrderLine orderline = new OrderLine (product, merchQty);
                order.OrderLines.Add (orderline);
            }
            else if (orderMenuSelection == 4)
            {
                PaymentOptions paymentMethod = GetPaymentMethod(); // need validation
                Payment payment = new Payment(0.00);

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
                        Console.WriteLine("Enter Your Check Number:");
                        Int64.TryParse(Console.ReadLine(), out checkNum);
                        Console.WriteLine("Enter Your Account Number:");
                        Int64.TryParse(Console.ReadLine(), out acctNum);
                        Console.WriteLine("Enter Your Routing Number:");
                        Int64.TryParse(Console.ReadLine(), out routeNum);
                        payment = new Payment(checkNum, acctNum, routeNum); // need actual values from program
                        break;
                }
                PrintReceipt(payment, order, foodOrder, drinkOrder, merchOrder, paymentMethod);
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

// Removed DisplayBill, it seemed redundant with all the information in the receipt.

void PrintReceipt(Payment payment, Order order, List<OrderLine> foodOrder, List<OrderLine> drinkOrder, List<OrderLine> merchOrder, PaymentOptions paymentMethod)
{
    double subtotal = order.OrderLines.Sum(x => x.ExtPrice);
    double tax = payment.Tax(subtotal);
    double cashTendered = payment.CashTotal;

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("                GOOD TIME BREWERY & EATS                ");
    Console.WriteLine("--------------------------------------------------------");
    Console.WriteLine(string.Format("{0,-40} | {1,-04} | {2, 0}", "Item", "Qty", "Price"));
    Console.WriteLine("------------------------------------------------------\n");

    Console.WriteLine("FOOD");
    Console.WriteLine("--------------------------------------------------------");
 
    foreach (OrderLine food in foodOrder)
    {
        Console.WriteLine(string.Format("{0,-40} | {1,-04} | {2, 0}",
        food.Product.Name, food.Qty, string.Format("{0:C}", food.ExtPrice)));
    }

    Console.WriteLine("\nDRINKS");
    Console.WriteLine("--------------------------------------------------------");

   foreach (OrderLine drink in drinkOrder)
    {
        Console.WriteLine(string.Format("{0,-40} | {1,-04} | {2, 0}",
        drink.Product.Name, drink.Qty, string.Format("{0:C}", drink.ExtPrice)));
    }

    Console.WriteLine("\nMERCHANDISE");
    Console.WriteLine("--------------------------------------------------------");

    foreach (OrderLine merch in merchOrder)
    {
        Console.WriteLine(string.Format("{0,-40} | {1,-04} | {2, 0}",
        merch.Product.Name, merch.Qty, string.Format("{0:C}", merch.ExtPrice)));
    }

    Console.Write("\nTOTAL");
    Console.WriteLine("\n--------------------------------------------------------");

    Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Subtotal", string.Format("{0:C}", subtotal)));
    Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Tax (6%)", string.Format("{0:C}", tax)));
    Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Total Bill", string.Format("{0:C}", subtotal + tax)));

    Console.Write("\nPAYMENT");
    Console.WriteLine("\n--------------------------------------------------------");

    switch (paymentMethod)
    {
        case PaymentOptions.CreditCard:
            Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Payment via Credit Card", payment.Last4()));
            break;
        
        case PaymentOptions.Cash:
            Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Cash Tendered", string.Format("{0:C}", cashTendered)));
            Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Change Returned", string.Format("{0:C}", (cashTendered - (subtotal + tax)))));
            break;
        case PaymentOptions.Check:
            Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Payment via Check #", payment.CheckNum));
            break;
    }
    Console.WriteLine("\n--------------------------------------------------------");
}