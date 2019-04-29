using System;

namespace LineCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Incorrect number pf arguments");
                Console.WriteLine("Usage: dotnet run FILE_FORMAT");
                return;
            }
            var lineCounting = new LineCounting(args[0]);
            var result = lineCounting.Count();
            Console.WriteLine("Result: {0} lines", result);
        }
    }
}
