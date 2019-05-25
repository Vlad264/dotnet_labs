using System;
using System.Text;
using VkNet.Exception;

namespace SocialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter login:");
            var login = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = ReadPassword();

            try
            {
                VKHandler vkHandler = new VKHandler(login, password);
            }
            catch (VkAuthorizationException e)
            {
                Console.WriteLine("Authorization error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Network error: " + e.Message);
            }
        }

        private static string ReadPassword()
        {
            var sb = new StringBuilder();
            bool flag = true;
            while (flag)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        flag = false;
                        break;
                    
                    case ConsoleKey.Backspace:
                        Console.Write("\b \b");
                        if (sb.Length > 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        break;
                    
                    default:
                        Console.Write("*");
                        sb.Append(key.KeyChar);
                        break;
                }
            }
            Console.WriteLine();
            return sb.ToString();
        }
    }
}