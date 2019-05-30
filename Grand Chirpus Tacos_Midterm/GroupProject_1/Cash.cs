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
            Console.Write($"Enter cash payment amount: $");
            var amountGivenString = Console.ReadLine();
            decimal amountGiven;

            while (!decimal.TryParse(amountGivenString, out amountGiven) || amountGiven < grandTotal)
            {
                Console.Clear();
                Console.WriteLine("Invalid entry!");
                Console.WriteLine();
                Console.Write($"Enter a cash amount greater than {String.Format("{0:C2}", grandTotal)}: $");
                amountGivenString = Console.ReadLine();
            }

            Console.Clear();

            var amountReturned = amountGiven - grandTotal;

            return $"Paid in cash: {String.Format("{0:C2}", amountGiven)} \nChange: {String.Format("{0:C2}", amountReturned)}";
        }
    }
}
