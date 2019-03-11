using System;

namespace Calendar
{
    class Calendar
    {
        private DateTime _date;
        private int _workDays;

        public Calendar(DateTime date) 
        {
            _date = date;
        }

        public void PrintMonth() 
        {
            PrintLayout();
            PrintDays();
        }

        public void PrintWorkDays() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("Workdays: " + _workDays + "        ");
            WriteNextLine();
        }

        private void PrintLayout() 
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Mo Tu We Th Fr ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Sa Su");
            WriteNextLine();
        }

        private void PrintDays()
        {
            var day = new DateTime(_date.Year, _date.Month, 1);
            while (day.Month == _date.Month)
            {
                for (var i = 0; i < 7; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = i < 5 ? ConsoleColor.DarkGray : ConsoleColor.Red;

                    if (i != 0) 
                    {
                        Console.Write(" ");
                    }
                    if (i + 1 < (int) day.DayOfWeek || day.Month != _date.Month)
                    {
                        Console.Write("  ");
                        continue;
                    }
                    if ((int) day.DayOfWeek < 5)
                    {
                        _workDays++;
                    }
                    Console.Write(String.Format("{0, 2}", day.Day));
                    day = day.AddDays(1);
                }
                WriteNextLine();
            }
        }

        private void WriteNextLine()
        {
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}