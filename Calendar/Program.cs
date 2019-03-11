using System;

namespace Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter date: ");
            var str = Console.ReadLine();
            if (DateTime.TryParse(str, out var date)) {
                Calendar calendar = new Calendar(date);
                calendar.PrintMonth();
                calendar.PrintWorkDays();
            }
            else
            {
                Console.WriteLine("Incorrect input!!! Exiting program...");
            }
        }
    }
}
