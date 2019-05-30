using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject_1
{
    public class Cash
    {
        public double Cost { get; set; }

        public double AmountReturned;

        //public Cash(double amountGiven, double cost)
        //{
        //    AmountGiven = amountGiven;
        //    Cost = cost;
        //}

        public void CashBack(double Cost)
        {
            Console.WriteLine("How much cash is given?");
            var userInput = Console.ReadLine();
            double.TryParse(userInput, out double amountGiven);

            AmountReturned = amountGiven - Cost;
            Console.WriteLine(AmountReturned);
        }
    }
}
