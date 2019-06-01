using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GroupProject_1
{
    class Check
    {        
        public static string GetCheckNumber()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please enter your check number: ");
            var checkNumber = Console.ReadLine();
            Console.ResetColor();

            while (!(Regex.IsMatch(checkNumber, @"^[0-9]{3,4}$")))
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Thats an invalid number.");
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter your check number: ");
                checkNumber = Console.ReadLine();
                Console.ResetColor();
            }
            Console.Clear();
            
            return $"Paid with check #{checkNumber}";
        }
    }
}