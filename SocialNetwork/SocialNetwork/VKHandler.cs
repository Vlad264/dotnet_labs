using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace SocialNetwork
{
    public class VKHandler
    {
        private const int AppId = 5288513;
        private readonly VkApi vk;
        private VkCollection<User> friends;
        private readonly Random random;

        public VKHandler(string login, string password)
        {
            var service = new ServiceCollection();
            service.AddAudioBypass();
            
            vk = new VkApi(service);
            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = AppId,
                Login = login,
                Password = password,
                Settings = Settings.Friends
            });
            
            var filter = new FriendsGetParams {Fields = ProfileFields.FirstName | ProfileFields.LastName};
            friends = vk.Friends.Get(filter);
            
            random = new Random();
        }

        public void WriteFriends()
        {
            var i = 1;
            Console.WriteLine("Friends:");
            foreach (var friend in friends)
            {
                Console.WriteLine(i + ")" + friend.FirstName + " " + friend.LastName);
                ++i;
            }
        }

        public User getUser(string fullName)
        {
            var split = fullName.Split();
            if (split.Length != 2)
            {
                throw new ArgumentException("Incorrect user name");
            }

            var first = split[0];
            var second = split[1];
            return friends.First(f => (f.FirstName == first && f.LastName == second)
                                      || (f.FirstName == second && f.LastName == first));
        }

        public void SendMessage(User user, string message)
        {
            var messageParams = new MessagesSendParams
            {
                Message = message,
                UserId = user.Id,
                RandomId = random.Next()
            };
            vk.Messages.Send(messageParams);
        }
    }
}