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

            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Enter the item #(1-12) that you want to order: ");

                Console.ResetColor();
                var itemSelectionString = Console.ReadLine();
                int itemSelection;

                while (!int.TryParse(itemSelectionString, out itemSelection) || itemSelection < 1 || itemSelection > 12)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine();
                    //fix that it doesn't show menu

                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Enter the item #(1-12) that you want to order: ");
                    itemSelectionString = Console.ReadLine();
                }

                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"How many {menuList[itemSelection].Name} would you like?: ");
                Console.ResetColor();
                var orderQtyString = Console.ReadLine();
                int orderQty;

                while (!int.TryParse(orderQtyString, out orderQty) || orderQty < 1)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Invalid entry!");
                    
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Enter the number of {menuList[itemSelection].Name} you would like to order: ");
                    orderQtyString = Console.ReadLine();
                }

                orderList.Add(new Order(menuList[itemSelection].Name, orderQty, (orderQty * (Decimal.Parse(menuList[itemSelection].Price)))));

                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"{orderList[orderCounter].ItemName} X {orderList[orderCounter].Qty} = {String.Format("{0:C2}", orderList[orderCounter].LinePrice)}\n");

                Console.ResetColor();

                orderCounter++;

                while (true)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Would you like something else? (y)es or (n)o: ");
                    userContinues = Console.ReadLine();
                    Console.ResetColor();
                    Console.Clear();
                    if (userContinues.Equals("y", StringComparison.OrdinalIgnoreCase) || userContinues.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        do
                        {
                            Console.Write("Would you like to see the menu again? Enter (y)es or (n)o: ");
                            var redisplayMenu = Console.ReadLine();
                            Console.Clear();
                            if (redisplayMenu.Equals("y", StringComparison.OrdinalIgnoreCase) || redisplayMenu.Equals("yes", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Clear();
                                Menu.CreateMenu();
                                break;
                            }
                            else if (redisplayMenu.Equals("n", StringComparison.OrdinalIgnoreCase) || redisplayMenu.Equals("no", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Invalid Entry. Please try again.");
                                Console.WriteLine();
                            }
                        } while (true);

                        break;
                    }
                    else if (userContinues.Equals("n", StringComparison.OrdinalIgnoreCase) || userContinues.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        loopforItemEntry = false;
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Invalid Entry. Please try again.");
                        Console.WriteLine();
                    }
                }

            } while (loopforItemEntry);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;

            decimal subTotal = 0;

            foreach (var item in orderList)
            {
                subTotal += item.LinePrice;
            }

            decimal salesTax = subTotal * .06m;
            decimal grandTotal = subTotal + salesTax;

            Console.WriteLine($"Subtotal: {String.Format("{0:C2}", subTotal)} \nSales tax: {String.Format("{0:C2}", salesTax)} \nGrand total: {String.Format("{0:C2}", grandTotal)}");

            Console.WriteLine();


            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("How are you paying? Enter \"1\" for Cash, \"2\" for Credit or \"3\" for Check: ");
            Console.ResetColor();


            var paymentMethodString = Console.ReadLine();
            int paymentMethod;

            while (!int.TryParse(paymentMethodString, out paymentMethod) || paymentMethod < 1 || paymentMethod > 3)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Invalid entry!");
                Console.WriteLine();

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("How are you paying? Enter \"1\" for Cash, \"2\" for Credit or \"3\" for Check: ");
                paymentMethodString = Console.ReadLine();
            }

            Console.Clear();


            if (paymentMethod == 1)
            {

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkGray;
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
                Console.ResetColor();
            }

            else if (paymentMethod == 2)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkGray;
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
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkGray;
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Thank you!");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
