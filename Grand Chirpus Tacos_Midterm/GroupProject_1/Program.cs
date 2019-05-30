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
                Console.Write("Please enter (y)es or (n)o: ");
                var userInput1 = Console.ReadLine().ToLower();
                Console.Clear();

                while (!(userInput1.Equals("y") || userInput1.Equals("yes") || userInput1.Equals("n") || userInput1.Equals("no")))
                {
                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to place an order?");
                    Console.Write("Please enter (y)es or (n)o: ");
                    userInput1 = Console.ReadLine().ToLower();
                    Console.Clear();
                }

                if (userInput1.Equals("y") || userInput1.Equals("yes"))
                {
                    Menu.CreateMenu();
                    Order.CreateOrder();
                }

                Console.Clear();
                Console.WriteLine("Are there any more customers?");
                Console.WriteLine();
                Console.Write("Please enter (y)es or (n)o: ");
                var newCustomer = Console.ReadLine().ToLower();
                Console.Clear();

                while (!(newCustomer.Equals("y") || newCustomer.Equals("yes") || newCustomer.Equals("n") || newCustomer.Equals("no")))
                {
                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine();
                    Console.Write("Please enter (y)es or (n)o: ");
                    newCustomer = Console.ReadLine().ToLower();
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