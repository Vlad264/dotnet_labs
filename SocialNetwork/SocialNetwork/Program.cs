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
                Run(vkHandler);
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

        private static void Run(VKHandler vkHandler)
        {
            while (true)
            {
                Console.WriteLine("Enter user name to write to this friend");
                Console.WriteLine("Enter \"friends\" to see friends list");
                Console.WriteLine("Enter \"exit\" to close program");
                var str = Console.ReadLine();
                switch (str)
                {
                    case "friends":
                        vkHandler.WriteFriends();
                        break;
                    
                    case "exit":
                        Environment.Exit(0);
                        break;
                    
                    default:
                        try
                        {
                            var user = vkHandler.getUser(str);
                            Console.WriteLine("Enter message:");
                            str = Console.ReadLine();
                            vkHandler.SendMessage(user, str);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;
                }
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