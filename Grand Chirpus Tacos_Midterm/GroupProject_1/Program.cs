using System;

namespace GroupProject_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var userContinue = true;
            while (userContinue)
            {
                Console.WriteLine("Welcome to Grand Chirpus Tacos!");
                Console.WriteLine();

                Console.WriteLine("Would you like to place an order?");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter (y)es or (n)o: ");
                var userInput1 = Console.ReadLine().ToLower();
                Console.ResetColor();
                Console.Clear();

                while (!(userInput1.Equals("y") || userInput1.Equals("yes") || userInput1.Equals("n") || userInput1.Equals("no")))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("Would you like to place an order?");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    
                    Console.Write("Please enter (y)es or (n)o: ");
                    userInput1 = Console.ReadLine().ToLower();
                    Console.ResetColor();
                    Console.Clear();
                }

                if (userInput1.Equals("y") || userInput1.Equals("yes"))
                {
                    //Menu.CreateMenu();
                    Order.CreateOrder();
                }

                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Are there any more customers?");
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter (y)es or (n)o: ");
                var newCustomer = Console.ReadLine().ToLower();
                Console.ResetColor();
                Console.Clear();

                while (!(newCustomer.Equals("y") || newCustomer.Equals("yes") || newCustomer.Equals("n") || newCustomer.Equals("no")))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Please enter (y)es or (n)o: ");
                    newCustomer = Console.ReadLine().ToLower();
                    Console.ResetColor();
                    Console.Clear();
                }

                if (newCustomer.Equals("n") || newCustomer.Equals("no"))
                {
                    userContinue = false;
                }

            }

            Console.WriteLine("OK, closing time. Goodbye!");
            Console.ReadKey();
        }

    }
}