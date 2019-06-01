using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GroupProject_1
{
    public class Credit
    {
        public static string TakeTheCreditCard()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please enter your Credit Card Number: ");
            var creditCard = Console.ReadLine();
            Console.ResetColor();

            while (!(Regex.IsMatch(creditCard, @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|6(?:011|5[0-9]{2})[0-9]{12}|(?:2131|1800|35\d{3})\d{11})$")))
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Invalid Credit Card #!");
                Console.WriteLine();                

                Console.BackgroundColor = ConsoleColor.Blue;           
                Console.Write("Please enter your Credit Card Number: ");
                creditCard = Console.ReadLine();
                Console.ResetColor();
            }

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please enter the CVV: ");
            var CVV = Console.ReadLine();
            Console.ResetColor();

            while (!(Regex.IsMatch(CVV, @"^[0-9]{3,4}$")))
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Invalid CVV!");
                Console.WriteLine();

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter the CVV: ");
                CVV = Console.ReadLine();
                Console.ResetColor();
            }

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please enter the expiration date (MMYY): ");
            var expireDate = Console.ReadLine();
            Console.ResetColor();

            while (!(Regex.IsMatch(expireDate, @"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$")))
            { 
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Invalid expiration date!");
                Console.WriteLine();

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter the expiration date (MMYY): ");
                expireDate = Console.ReadLine();
                Console.ResetColor();
            }


            Console.Clear();

            return $"Paid with credit card: XXXX-XXXX-XXXX-{creditCard.Substring(12)}";
        }
    }
}
            