using System;

namespace GroupProject_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Grand Chirpus Tacos!");
            Console.WriteLine();

            Console.WriteLine("Would you like to place an order?");
            Console.Write("Please enter (y)es or (n)o: ");
            var userInput1 = Console.ReadLine().ToLower();
            Console.WriteLine();

            var continueLoop = true;

            while (continueLoop)
            {

                if (userInput1.Equals("y", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    while (userInput1.Equals("y", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        var continueLoop2 = true;

                        while (continueLoop2)
                        {

                            Console.WriteLine("Please select and item off the menu...");
                            Console.WriteLine();  
                            //var userInput1 = Console.ReadLine().ToLower();

                            //display menu list
                            Menu.CreateMenu();                          

                            Console.WriteLine("How many would you like?");
                            var userInput2 = Console.ReadLine();

                            //run choose item class
                            Console.WriteLine("Your total is:");
                            Console.WriteLine();
                            Console.WriteLine("Would you like to order anything else?");
                            //if yes, redisplay list
                            Console.WriteLine("How are you paying? Cash, credit or check?");
                            var userInput3 = Console.ReadLine();
                            //Call payment class

                            Cash cash = new Cash(6, 5);
                            var moneyBack = cash.CashBack();
                            Console.WriteLine(moneyBack);
                            Console.ReadKey();
                            //cash(8.00, 6.00);
                            //Console.WriteLine("Here is your receipt");
                            ////Display receipt
                            //Console.WriteLine("Thank you!");

                            Console.WriteLine("Are there any more customers?");
                            Console.Write("Please enter (y)es or (n)o: ");
                            userInput1 = Console.ReadLine().ToLower();
                            Console.WriteLine();

                            var continueLoop3 = true;

                            while (continueLoop3)
                            {
                                if (userInput1.Equals("y", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("yes", StringComparison.OrdinalIgnoreCase))
                                {
                                    break;
                                }
                                else if (userInput1.Equals("n", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("no", StringComparison.OrdinalIgnoreCase))
                                {
                                    continueLoop2 = false;                                  
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid entry. Please try again.");
                                    Console.WriteLine();
                                    Console.WriteLine("Are there any more customers?");
                                    Console.Write("Please enter (y)es or (n)o: ");
                                    userInput1 = Console.ReadLine().ToLower();
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                    break;
                }
                else if (userInput1.Equals("n", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to place an order?");
                    Console.Write("Please enter (y)es or (n)o: ");
                    userInput1 = Console.ReadLine().ToLower();
                    Console.WriteLine();
                }
            }

            Console.WriteLine("OK, closing time. Goodbye!");
                Console.ReadKey();
        }
    }
}
