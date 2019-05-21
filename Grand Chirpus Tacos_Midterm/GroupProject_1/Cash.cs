using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject_1
{
    class Cash
    {
        public decimal AmountGiven { get; set; }
        public decimal Cost { get; set; }
        public decimal AmountReturned { get; set; }

        public Cash(decimal amountGiven, decimal cost/*, decimal amountReturned*/)
        {
            AmountGiven = amountGiven;
            Cost = cost;
            //AmountReturned = amountReturned;
        }

        public decimal CashBack()
        {
            AmountReturned = AmountGiven - Cost;
            return AmountReturned;
        }
    }
}
