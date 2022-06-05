using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDesign
{
    public struct UserProfile
    {
        public string PhoneNumber;
        public string UserName;
        public string Email;
        public string IdentificationLevel;
        public string Ban;

    }
    public class UserData
    {
        public static string OldToken { get; set; } = string.Empty;
        public static string Token { get; set; }
        public static string TelegramChatID { get; set; } = string.Empty;
        public static string Proxy { get; set; } = string.Empty;

        public static UserProfile UserProfile = new UserProfile();
    }
}
