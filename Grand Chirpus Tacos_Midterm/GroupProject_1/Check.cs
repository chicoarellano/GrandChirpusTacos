using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GroupProject_1
{
    class Check
    {
        public int counter { get; set; }

        public void GetCheckNumber()
        {
            while (counter < 3)
            {
                Console.WriteLine("Please enter your check number");
                var checkNumber = Console.ReadLine();

                if (Regex.IsMatch(checkNumber, @"^[0-9]{3,4}$"))
                {
                    Console.WriteLine("Thank you for your payment!");
                    break; 
                }
                else
                {
                    Console.WriteLine("Thats invalid.");
                    counter++;
                }

            }
        }
    }
}