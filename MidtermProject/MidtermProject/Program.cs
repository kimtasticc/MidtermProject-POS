using MidtermProject;

Setup.Run();
ProductFile productFile = new ProductFile();
Order order = new Order();
Validation Validation = new Validation();

int mainMenuSelection = 0;
int[] mainMenuOptions = new int[2] { 1, 2 };
int mainMenuCounter = 0;
int orderMenuSelection = 0;
int[] orderMenuOptions = new int[4] { 1, 2, 3, 4 };
string insertSpace = " ";

while (true)
{
    mainMenuCounter++;
    if (mainMenuCounter > 1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.WriteLine("Invalid selection. Please choose an option from the menu.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    mainMenuSelection = GetMainMenuSelection();
    if (mainMenuSelection == 1)
    {
        Console.Clear();
        mainMenuCounter = 0;
        List<OrderLine> foodOrder = new List<OrderLine>();
        List<OrderLine> drinkOrder = new List<OrderLine>();
        List<OrderLine> merchOrder = new List<OrderLine>();

        while (true)
        {
            orderMenuSelection = GetOrderMenuSelection();
            if (orderMenuSelection == 1)
            {
                Console.Clear();
                int foodMenuSelection = 0;
                List<int> foodIds = new List<int>();
                foreach (Product p in productFile.products.Where(x => x.Type == "Food"))
                {
                    foodIds.Add(p.ID);
                }
                foodMenuSelection = GetFoodMenuSelection(foodIds);
                int qty = 0;
                qty = GetUserQuantity();
                Product product = productFile.products.Where(x => x.ID == foodMenuSelection).FirstOrDefault();
                OrderLine orderLine = new OrderLine(product, qty);
                order.OrderLines.Add(orderLine);
                foodOrder.Add(orderLine);
                Console.Clear();
            }
            else if (orderMenuSelection == 2)
            {
                Console.Clear();
                int drinkMenuSelection = 0;
                List<int> drinkIds = new List<int>();
                foreach (Product p in productFile.products.Where(x => x.Type == "Drink"))
                {
                    drinkIds.Add(p.ID);
                }
                drinkMenuSelection = GetDrinkMenuSelection(drinkIds);
                int qty = 0;
                qty = GetUserQuantity();
                Product product = productFile.products.Where(x => x.ID == drinkMenuSelection).FirstOrDefault();
                OrderLine orderLine = new OrderLine(product, qty);
                order.OrderLines.Add(orderLine);
                drinkOrder.Add(orderLine);
                Console.Clear();

            }
            else if (orderMenuSelection == 3)
            {
                Console.Clear();
                int merchMenuSelection = 0;
                List<int> merchIds = new List<int>();
                foreach (Product p in productFile.products.Where(x => x.Type == "Merchandise"))
                {
                    merchIds.Add(p.ID);
                }
                merchMenuSelection = GetMerchMenuSelection(merchIds);
                int qty = 0;
                qty = GetUserQuantity();
                Product product = productFile.products.Where(x => x.ID == merchMenuSelection).FirstOrDefault();
                OrderLine orderLine = new OrderLine(product, qty);
                order.OrderLines.Add(orderLine);
                merchOrder.Add(orderLine);
                Console.Clear();

            }
            else if (orderMenuSelection == 4)
            {
                Console.Clear();
                Payment payment = new Payment(0.00);
                PaymentOptions paymentMethod = GetPaymentMethod(payment);

                switch (paymentMethod)
                {
                    case PaymentOptions.CreditCard:
                        string ccNum = "";
                        DateTime expDate = new DateTime();
                        int cvv = 0;
                        while (true)
                        {
                            Console.WriteLine("Enter 16-Digit Credit Card Number:");
                            string userCreditCardNumberInputRaw = Console.ReadLine();
                            bool isValid = Validation.ValidateCreditCardNumber(userCreditCardNumberInputRaw, out string validationResponse, out string userCreditCardNumberInputClean);
                            if (isValid)
                            {
                                ccNum = userCreditCardNumberInputClean;
                                break;
                            }
                            else
                            {
                                PrintValidationResponse(validationResponse);
                            }
                        }
                        while (true)
                        {
                            Console.WriteLine("Enter Expiration Date (mm/dd/yy)");
                            string userCreditCardExpirationDateRaw = Console.ReadLine();
                            bool isValid = Validation.ValidateCreditCardExpirationDate(userCreditCardExpirationDateRaw, out string validationResponse, out DateTime userDateValue);
                            if (isValid)
                            {
                                expDate = userDateValue;
                                break;
                            }
                            else
                            {
                                PrintValidationResponse(validationResponse);
                            }
                        }
                        while (true)
                        {
                            Console.WriteLine("Enter 3-Digit CVV");
                            string userCreditCardCVVRaw = Console.ReadLine();
                            bool isValid = Validation.ValidateCreditCardCVVNumber(userCreditCardCVVRaw, out string validationResponse, out int userCreditCardCVVClean);
                            if (isValid)
                            {
                                cvv = userCreditCardCVVClean;
                                break;
                            }
                            else
                            {
                                PrintValidationResponse(validationResponse);
                            }
                        }
                        payment = new Payment(ccNum, cvv, expDate);
                        break;

                    case PaymentOptions.Cash:
                        double cashTendered = 0;
                        while (true)
                        {
                            Console.WriteLine("Enter cash tendered:");
                            string userCashInputRaw = Console.ReadLine();
                            bool isValid = Validation.ValidateCashTendered(userCashInputRaw, payment.GrandTotal, out string validationResponse, out double userCashInput);
                            if (isValid)
                            {
                                cashTendered = userCashInput;
                                break;
                            }
                            else
                            {
                                PrintValidationResponse(validationResponse);
                            }
                        }
                        payment = new Payment(cashTendered);
                        break;

                    case PaymentOptions.Check:
                        long checkNum = 0;
                        long acctNum = 0;
                        long routeNum = 0;
                        while (true) 
                        {
                            Console.WriteLine("Enter Your Check Number:");
                            string userCheckNumberRaw = Console.ReadLine();
                            bool isValid = Validation.ValidateCheckNumber(userCheckNumberRaw, out string validationResponse, out string userCheckNumberClean);
                            if (isValid)
                            {
                                checkNum = Convert.ToInt64(userCheckNumberClean);
                                break;
                            }
                            else
                            {
                                PrintValidationResponse(validationResponse);
                            }
                        }
                        while (true)
                        {
                            Console.WriteLine("Enter Your Account Number:");
                            string userCheckAccountNumberRaw = Console.ReadLine();
                            bool isValid = Validation.ValidateCheckAccountNumber(userCheckAccountNumberRaw, out string validationResponse, out string userCheckAccountNumberClean);
                            if (isValid)
                            {
                                acctNum = Convert.ToInt64(userCheckAccountNumberClean);
                                break;
                            }
                            else
                            {
                                PrintValidationResponse(validationResponse);
                            }
                        }
                        while (true)
                        {
                            Console.WriteLine("Enter Your 9-Digit Routing Number:");
                            string userCheckRoutingNumberRaw = Console.ReadLine();
                            bool isValid = Validation.ValidateCheckRoutingNumber(userCheckRoutingNumberRaw, out string validationResponse, out string userCheckRoutingNumberClean);
                            if (isValid)
                            {
                                routeNum = Convert.ToInt64(userCheckRoutingNumberClean);
                                break;
                            }
                            else
                            {
                                PrintValidationResponse(validationResponse);
                            }
                        }
                        payment = new Payment(checkNum, acctNum, routeNum);
                        break;
                }
                PrintReceipt(payment, order, foodOrder, drinkOrder, merchOrder, paymentMethod);
                break;
            }
        }
    }
    else if (mainMenuSelection == 2)
    {
        break;
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
    DisplayMainMenu();
    int maxMenuOptionNumber = 2;
    bool isMainMenu = true;
    return GetUserMenuSelection(maxMenuOptionNumber, isMainMenu);
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
    Console.WriteLine($"Enter 4 to Cash-out.");
}

int GetOrderMenuSelection()
{
    DisplayOrderMenu();
    int maxMenuOptionNumber = 4;
    return GetUserMenuSelection(maxMenuOptionNumber, false);
}
PaymentOptions GetPaymentMethod(Payment payment)
{
    int paymentMethod = 0;
    double subtotal = order.OrderLines.Sum(x => x.ExtPrice);
    double tax = payment.Tax(subtotal);

    Console.WriteLine("Your Order Total is:");
    Console.WriteLine($"Subtotal: {subtotal.ToString("C")}");
    Console.WriteLine($"Tax (6%): {tax.ToString("C")}");
    payment.GrandTotal = subtotal + tax;
    Console.WriteLine($"Total Bill: {payment.GrandTotal.ToString("C")}");
    Console.WriteLine();

    while (true)
    {
        Console.WriteLine("Choose from this list:");
        Console.WriteLine("1 Credit Card");
        Console.WriteLine("2 Cash");
        Console.WriteLine("3 Check");
        int maxMenuOptionNumber = 3;
        string userInputMenuSelectionRaw = Console.ReadLine();
        bool isValid = Validation.ValidateMenuSelectionInput(userInputMenuSelectionRaw, maxMenuOptionNumber, out string validationResponse, out int paymentMethodOut);
        if (isValid)
        {
            paymentMethod = paymentMethodOut;
            break;
        }
        else
        {
            PrintValidationResponse(validationResponse);
        }
    }

    PaymentOptions paymentOptions = new PaymentOptions();

    if (paymentMethod == 1)
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

void DisplayFoodMenu()
{
    Console.WriteLine($"".PadRight(61, '*'));
    Console.WriteLine("FOOD");
    Console.WriteLine($"".PadRight(61, '*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Food"))
    {
        Console.WriteLine($"{p.ID} - {p.Name.PadRight(51, '.')}{p.Price.ToString("C").PadLeft(6, '.'):C2}");
        Console.WriteLine($"{insertSpace.PadLeft(5, ' ')} {p.Description}");
        Console.WriteLine();
    }
}

int GetFoodMenuSelection(List<int> foodIds)
{
    while (true)
    {
        DisplayFoodMenu();
        int selection = -1;
        string userInputOrderedItemRaw = Console.ReadLine();
        bool isValid = Validation.ValidateOrderedItemInput(userInputOrderedItemRaw, foodIds, out string validationResponse, out int selectionOut);
        if (isValid)
        {
            selection = selectionOut;
            return selection;
        }
        else
        {
            PrintValidationResponse(validationResponse);
        }
    }
}

void DisplayDrinkMenu()
{
    Console.WriteLine($"".PadRight(61, '*'));
    Console.WriteLine("DRINKS");
    Console.WriteLine($"".PadRight(61, '*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Drink"))
    {
        Console.WriteLine($"{p.ID} - {p.Name.PadRight(51, '.')}{p.Price.ToString("C").PadLeft(6, '.'):C2}");
        Console.WriteLine($"{insertSpace.PadLeft(5, ' ')} {p.Description}");
        Console.WriteLine();
    }
}

int GetDrinkMenuSelection(List<int> drinkIds)
{
    while (true)
    {
        DisplayDrinkMenu();
        int selection = -1;
        string userInputOrderedItemRaw = Console.ReadLine();
        bool isValid = Validation.ValidateOrderedItemInput(userInputOrderedItemRaw, drinkIds, out string validationResponse, out int selectionOut);
        if (isValid)
        {
            selection = selectionOut;
            return selection;
        }
        else
        {
            PrintValidationResponse(validationResponse);
        }
    }
}

void DisplayMerchMenu()
{
    Console.WriteLine($"".PadRight(61, '*'));
    Console.WriteLine("MERCHANDISE");
    Console.WriteLine($"".PadRight(61, '*'));
    foreach (Product p in productFile.products.Where(x => x.Type == "Merchandise"))
    {
        Console.WriteLine($"{p.ID} - {p.Name.PadRight(51, '.')}{p.Price.ToString("C").PadLeft(6, '.'):C2}");
        Console.WriteLine($"{insertSpace.PadLeft(5, ' ')} {p.Description}");
        Console.WriteLine();
    }
}

int GetMerchMenuSelection(List<int> merchIds)
{
    while (true)
    {
        DisplayMerchMenu();
        int selection = -1;
        string userInputOrderedItemRaw = Console.ReadLine();
        bool isValid = Validation.ValidateOrderedItemInput(userInputOrderedItemRaw, merchIds, out string validationResponse, out int selectionOut);
        if (isValid)
        {
            selection = selectionOut;
            return selection;
        }
        else
        {
            PrintValidationResponse(validationResponse);
        }
    }
}

void PrintReceipt(Payment payment, Order order, List<OrderLine> foodOrder, List<OrderLine> drinkOrder, List<OrderLine> merchOrder, PaymentOptions paymentMethod)
{
    double subtotal = order.OrderLines.Sum(x => x.ExtPrice);
    double tax = payment.Tax(subtotal);
    double grandTotal = subtotal + tax;
    double cashTendered = payment.CashTotal;

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("                GOOD TIME BREWERY & EATS                ");
    Console.WriteLine("--------------------------------------------------------");
    Console.WriteLine(string.Format("{0,-40} | {1,-04} | {2, 0}", "Item", "Qty", "Price"));
    Console.WriteLine("--------------------------------------------------------\n");

    if (foodOrder.Count > 0)
    {
        foreach (OrderLine food in foodOrder)
        {
            Console.WriteLine("FOOD");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-40} | {1,-04} | {2, 0}",
            food.Product.Name, food.Qty, string.Format("{0:C}", food.ExtPrice.ToString("C"))));
        }
    }

    if (drinkOrder.Count > 0)
    {
        foreach (OrderLine drink in drinkOrder)
        {
            Console.WriteLine("\nDRINKS");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-40} | {1,-04} | {2, 0}",
            drink.Product.Name, drink.Qty, string.Format("{0:C}", drink.ExtPrice.ToString("C"))));
        }
    }

    if (merchOrder.Count > 0)
    {
        foreach (OrderLine merch in merchOrder)
        {
            Console.WriteLine("\nMERCHANDISE");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-40} | {1,-04} | {2, 0}",
            merch.Product.Name, merch.Qty, string.Format("{0:C}", merch.ExtPrice.ToString("C"))));
        }
    }
    Console.Write("\nTOTAL");
    Console.WriteLine("\n--------------------------------------------------------");
    Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Subtotal", string.Format("{0:C}", subtotal.ToString("C"))));
    Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Tax (6%)", string.Format("{0:C}", tax.ToString("C"))));
    Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Total Bill", string.Format("{0:C}", grandTotal.ToString("C"))));
    Console.Write("\nPAYMENT");
    Console.WriteLine("\n--------------------------------------------------------");

    switch (paymentMethod)
    {
        case PaymentOptions.CreditCard:
            Console.WriteLine(string.Format("{0,-29} | {1, 0}", "Payment via Credit Card", payment.Last4()));
            break;

        case PaymentOptions.Cash:
            Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Cash Tendered", string.Format("{0:C}", cashTendered.ToString("C"))));
            double changeReturned = cashTendered - grandTotal;
            Console.WriteLine(string.Format("{0,-47} | {1, 0}", "Change Returned", string.Format("{0:C}", changeReturned.ToString("C"))));
            break;
        case PaymentOptions.Check:
            Console.WriteLine(string.Format("{0,-40} | {1, 0}", "Payment via Check", " Check #: " + payment.CheckNum));
            break;
    }
    Console.WriteLine("\n--------------------------------------------------------");
    Console.WriteLine();
    Console.WriteLine("Press any key to return to the main menu");
    Console.ReadKey();
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Gray;
}

int GetUserMenuSelection(int maxMenuOptionNumber, bool isMainMenu)
{
    while (true)
    {
        int selection = -1;
        string userInputMenuSelectionRaw = Console.ReadLine();
        bool isValid = Validation.ValidateMenuSelectionInput(userInputMenuSelectionRaw, maxMenuOptionNumber, out string validationResponse, out int userInputMenuSelection);
        if (isValid)
        {
            selection = userInputMenuSelection;
            return selection;
        }
        else
        {
            PrintValidationResponse(validationResponse);
            if (isMainMenu)
            {
                DisplayMainMenu();
            }
            else
            {
                DisplayOrderMenu();
            }
        }
    }
}

int GetUserQuantity()
{
    while (true)
    {
        int qty = 0;
        Console.WriteLine("Please enter Qty: ");
        string userInputQtyRaw = Console.ReadLine();
        bool isValid = Validation.ValidateQuantityInput(userInputQtyRaw, out string validationResponse, out qty);
        if (isValid)
        {
            return qty;
        }
        else
        {
            PrintValidationResponse(validationResponse);
        }
    }
}

void PrintValidationResponse(string validationResponse)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine();
    Console.WriteLine(validationResponse);
    Console.WriteLine("Press any key to continue");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.ReadKey();
    Console.Clear();
}