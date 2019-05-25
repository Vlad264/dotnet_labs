using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace SocialNetwork
{
    public class VKHandler
    {
        private const int AppId = 5288513;
        private readonly VkApi vk;
        private VkCollection<User> friends;

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
        }
    }
}