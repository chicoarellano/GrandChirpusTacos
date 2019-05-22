using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject_1
{
    class Cash
    {
        public decimal AmountGiven { get; set; }
        public decimal Cost { get; set; }

        public decimal AmountReturned;

        public Cash(decimal amountGiven, decimal cost)
        {
            AmountGiven = amountGiven;
            Cost = cost;
        }

        public decimal CashBack()
        {
            AmountReturned = AmountGiven - Cost;
            return AmountReturned;
        }
    }
}
