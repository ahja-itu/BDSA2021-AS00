using System;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Input year to check it it was a leap year: ");
            var input = Console.ReadLine();
            try
            {
                int year = Int32.Parse(input);
                string answer = (IsLeapYear(year)) ? "yay" : "nay";
                Console.WriteLine(answer);

            }
            catch(FormatException)
            {
                Console.WriteLine($"Unable to parse input \"{input}\"");
            }
        }

        public static bool IsLeapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            } 
            else if (year % 100 == 0)
            {
                return false;
            } 
            else if (year % 4 == 0)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}
