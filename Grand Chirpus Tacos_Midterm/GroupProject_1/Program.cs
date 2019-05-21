using System;

namespace GroupProject_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Grand Chirpus Tacos");
                Console.WriteLine();
                while (true)
                {
                    Console.WriteLine("Would you like to see the menu?");
                    var userInput1 = Console.ReadLine();

                    if (userInput1.Equals("y", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        //display menu list
                        Menu.CreateMenu();

                        Console.WriteLine("How many would you like?");
                        var userInput2 = Console.ReadLine();

                        //run choose item class
                        Console.WriteLine("Your total is:");
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
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
