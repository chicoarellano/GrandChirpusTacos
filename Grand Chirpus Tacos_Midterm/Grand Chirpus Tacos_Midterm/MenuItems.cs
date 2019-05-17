using System;
using System.Collections.Generic;
using System.Text;

namespace Grand_Chirpus_Tacos_Midterm
{
     public abstract class MenuItems
     {
        public Dictionary<string, double> menu = new Dictionary<string, double>()
        {
            {"taco", 1.99},
            {"quesadilla", 2.50 },
        };

     }
}
