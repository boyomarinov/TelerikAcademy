using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Razor;

namespace Forum.Services.Utilities
{
    public static class SessionGenerator
    {
        private static Random rand = new Random();
        private const int SessionKeyLength = 50;
        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";

        public static string GenerateSessionKey(int userId)
        {
            StringBuilder sKeyBuilder = new StringBuilder(SessionKeyLength);
            sKeyBuilder.Append(userId);
            while (sKeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                sKeyBuilder.Append(SessionKeyChars[index]);
            }
            return sKeyBuilder.ToString();
        }
    }
}