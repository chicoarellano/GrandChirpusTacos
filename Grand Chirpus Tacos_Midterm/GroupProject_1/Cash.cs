using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject_1
{
    class Cash
    {
        public static string CashBack(decimal grandTotal)
        {            
            Console.WriteLine($"Your total is: {String.Format("{0:C2}", grandTotal)}");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Enter cash payment amount: $");
            var amountGivenString = Console.ReadLine();
            decimal amountGiven;
            Console.ResetColor();

            while (!decimal.TryParse(amountGivenString, out amountGiven) || amountGiven < grandTotal)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Invalid entry!");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine($"Your total is: {String.Format("{0:C2}", grandTotal)}");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Enter a cash amount greater than the total: $");
                amountGivenString = Console.ReadLine();
                Console.ResetColor();
            }

            Console.Clear();

            var amountReturned = amountGiven - grandTotal;
            

            return $"Paid in cash: {String.Format("{0:C2}", amountGiven)} \nChange: {String.Format("{0:C2}", amountReturned)}";
        }
    }
}
