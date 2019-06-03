using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject_1
{
    class Order
    {
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public decimal LinePrice { get; set; }

        public Order(string itemName, int qty, decimal linePrice)
        {
            ItemName = itemName;
            Qty = qty;
            LinePrice = linePrice;
        }

        public static void CreateOrder()
        {
            string line;
            var menuList = new List<Menu>();
            var orderList = new List<Order>();

            System.IO.StreamReader file =
                new System.IO.StreamReader("productlist.txt");
            while ((line = file.ReadLine()) != null)
            {
                var words = line.Split(',');
                menuList.Add(new Menu(words[0], words[1], words[2], words[3], words[4]));
            }

            file.Close();

            string userContinues;
            int orderCounter = 0;
            bool loopforItemEntry = true;

            Menu.CreateMenu();

            do
            {
                
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Enter the item #(1-12) that you want to order: ");
                
                var itemSelectionString = Console.ReadLine();
                int itemSelection;

                Console.ResetColor();

                while (!int.TryParse(itemSelectionString, out itemSelection) || itemSelection < 1 || itemSelection > 12)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine();

                    Console.ResetColor();
                    Menu.CreateMenu();

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Enter the item #(1-12) that you want to order: ");
                    itemSelectionString = Console.ReadLine();

                    Console.ResetColor();
                }

                Console.Clear();                
                Console.WriteLine($"How many {menuList[itemSelection].Name} would you like?: ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter number: ");

                var orderQtyString = Console.ReadLine();
                int orderQty;

                Console.ResetColor();

                while (!int.TryParse(orderQtyString, out orderQty) || orderQty < 1)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Invalid entry!");
                    
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine($"How many {menuList[itemSelection].Name} would you like?");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Enter the number: ");
                    orderQtyString = Console.ReadLine();
                    Console.ResetColor();

                }

                orderList.Add(new Order(menuList[itemSelection].Name, orderQty, (orderQty * (Decimal.Parse(menuList[itemSelection].Price)))));

                Console.Clear();                

                Console.WriteLine($"{orderList[orderCounter].ItemName} X {orderList[orderCounter].Qty} = {String.Format("{0:C2}", orderList[orderCounter].LinePrice)}\n");                


                Console.WriteLine("Would you like to order something else?");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter (y)es or (n)o: ");
                userContinues = Console.ReadLine().ToLower();
                Console.ResetColor();
                Console.Clear();

                while (!(userContinues.Equals("y") || userContinues.Equals("yes") || userContinues.Equals("n") || userContinues.Equals("no")))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Invalid entry!");                    
                    Console.ResetColor();
                    Console.WriteLine();                    
                    Console.WriteLine("Would you like to order something else?");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Please enter (y)es or (n)o: ");
                    userContinues = Console.ReadLine().ToLower();
                    Console.ResetColor();
                    Console.Clear();
                }

                if (userContinues.Equals("y") || userContinues.Equals("yes"))
                {
                    Console.WriteLine("Would you like to see the menu again?");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter (y)es or (n)o: ");
                    var redisplayMenu = Console.ReadLine();
                    Console.ResetColor();
                    Console.Clear();

                    while (!(redisplayMenu.Equals("y") || redisplayMenu.Equals("yes") || redisplayMenu.Equals("n") || redisplayMenu.Equals("no")))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Invalid entry!");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Would you like to see the menu again?");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Enter (y)es or (n)o: ");
                        redisplayMenu = Console.ReadLine();
                        Console.ResetColor();
                        Console.Clear();
                    }

                    if (redisplayMenu.Equals("y") || redisplayMenu.Equals("yes"))
                    {
                        Console.Clear();
                        Menu.CreateMenu();
                    }

                    else
                    {
                        Console.Clear();
                    }
                }

                else
                {
                    loopforItemEntry = false;
                }

                orderCounter++;               


            } while (loopforItemEntry);            

            decimal subTotal = 0;

            foreach (var item in orderList)
            {
                subTotal += item.LinePrice;
            }

            decimal salesTax = subTotal * .06m;
            decimal grandTotal = subTotal + salesTax;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Subtotal: {String.Format("{0:C2}", subTotal)} \nSales tax: {String.Format("{0:C2}", salesTax)} \nGrand total: {String.Format("{0:C2}", grandTotal)}");

            Console.WriteLine();

            Console.ResetColor();

            Console.WriteLine("How are you paying?");
            Console.Write("Enter ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\"1\" for Cash");
            Console.ResetColor();
            Console.Write(", ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\"2\" for Credit");
            Console.ResetColor();
            Console.Write(" or ");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\"3\" for Check");                
            Console.ResetColor();
            Console.Write(": ");
            var paymentMethodString = Console.ReadLine();
            int paymentMethod;
            

            while (!int.TryParse(paymentMethodString, out paymentMethod) || paymentMethod < 1 || paymentMethod > 3)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Invalid entry!");
                Console.WriteLine();
                Console.ResetColor();

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"Subtotal: {String.Format("{0:C2}", subTotal)} \nSales tax: {String.Format("{0:C2}", salesTax)} \nGrand total: {String.Format("{0:C2}", grandTotal)}");

                Console.WriteLine();

                Console.ResetColor();

                Console.WriteLine("How are you paying?");
                Console.Write("Enter ");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\"1\" for Cash");
                Console.ResetColor();
                Console.Write(", ");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\"2\" for Credit");
                Console.ResetColor();
                Console.Write(" or ");
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\"3\" for Check");
                Console.ResetColor();
                Console.Write(": ");
                paymentMethodString = Console.ReadLine();
            }

            Console.Clear();


            if (paymentMethod == 1)
            {
                //run cash function
                var cashBackString = Cash.CashBack(grandTotal);                

                // configure receipt here          
                Console.Write("Item");
                Console.SetCursorPosition(15, 0);
                Console.Write("Qty");
                Console.SetCursorPosition(25, 0);
                Console.WriteLine("Price");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("=================================");
                Console.WriteLine();

                int cursorPosition = 2;

                foreach (var item in orderList)
                {
                    Console.SetCursorPosition(0, cursorPosition);
                    Console.Write($"{item.ItemName}");
                    Console.SetCursorPosition(15, cursorPosition);
                    Console.Write($"{item.Qty}");
                    Console.SetCursorPosition(25, cursorPosition);
                    Console.WriteLine($"{String.Format("{0:C2}", item.LinePrice)}");

                    cursorPosition += 1;
                }

                Console.WriteLine();
                Console.WriteLine($"Subtotal: {String.Format("{0:C2}", subTotal)} \nSales tax: {String.Format("{0:C2}", salesTax)} \nGrand total: {String.Format("{0:C2}", grandTotal)}");
                Console.WriteLine();

                //reciept

                Console.WriteLine(cashBackString);
                
            }

            else if (paymentMethod == 2)
            {
                //run credit function
                var creditString = Credit.TakeTheCreditCard();

                // configure receipt here
                Console.Write("Item");
                Console.SetCursorPosition(15, 0);
                Console.Write("Qty");
                Console.SetCursorPosition(25, 0);
                Console.WriteLine("Price");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("=================================");
                Console.WriteLine();

                int cursorPosition = 2;

                foreach (var item in orderList)
                {
                    Console.SetCursorPosition(0, cursorPosition);
                    Console.Write($"{item.ItemName}");
                    Console.SetCursorPosition(15, cursorPosition);
                    Console.Write($"{item.Qty}");
                    Console.SetCursorPosition(25, cursorPosition);
                    Console.WriteLine($"{String.Format("{0:C2}", item.LinePrice)}");

                    cursorPosition += 1;
                }

                Console.WriteLine();
                Console.WriteLine($"Subtotal: {String.Format("{0:C2}", subTotal)} \nSales tax: {String.Format("{0:C2}", salesTax)} \nGrand total: {String.Format("{0:C2}", grandTotal)}");
                Console.WriteLine();

                //reciept

                Console.WriteLine(creditString);
                Console.ResetColor();
            }

            else
            {
                //run check function
                var checkString = Check.GetCheckNumber();

                // configure receipt here
                Console.Write("Item");
                Console.SetCursorPosition(15, 0);
                Console.Write("Qty");
                Console.SetCursorPosition(25, 0);
                Console.WriteLine("Price");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("=================================");
                Console.WriteLine();

                int cursorPosition = 2;

                foreach (var item in orderList)
                {
                    Console.SetCursorPosition(0, cursorPosition);
                    Console.Write($"{item.ItemName}");
                    Console.SetCursorPosition(15, cursorPosition);
                    Console.Write($"{item.Qty}");
                    Console.SetCursorPosition(25, cursorPosition);
                    Console.WriteLine($"{String.Format("{0:C2}", item.LinePrice)}");

                    cursorPosition += 1;
                }

                Console.WriteLine();
                Console.WriteLine($"Subtotal: {String.Format("{0:C2}", subTotal)} \nSales tax: {String.Format("{0:C2}", salesTax)} \nGrand total: {String.Format("{0:C2}", grandTotal)}");
                Console.WriteLine();

                //reciept

                Console.WriteLine(checkString);
                Console.ResetColor();
            }

            Console.WriteLine();            
            Console.WriteLine("Thank you!");            
            Console.ReadKey();
            Console.ResetColor();
        }
    }
}
