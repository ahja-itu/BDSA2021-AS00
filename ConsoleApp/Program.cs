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
                int year;
                if (!Int32.TryParse(input, out year))
                {
                    Console.WriteLine("invalid input: the input was not a number");
                }
                string answer = (IsLeapYear(year)) ? "yay" : "nay";
                Console.WriteLine(answer);

            }
            catch(ArgumentException e)
            {
                Console.WriteLine($"The input year was not large enough: #{e.Message}");
            }
        }

        public static bool IsLeapYear(int year)
        {
            if (year < 1582)
            {
                throw new ArgumentException($"the input year \"#{year}\" should be greater or equal to 1582");
            }
            else if (year % 400 == 0)
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
