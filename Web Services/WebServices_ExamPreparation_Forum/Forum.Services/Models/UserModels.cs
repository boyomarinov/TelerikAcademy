using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Model;

namespace Forum.Services.Models
{
    using System;

    public class UserRegisterRequestModel
    {
        public static Func<UserRegisterRequestModel, User> ToEntity { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public string AuthCode { get; set; }

        static UserRegisterRequestModel()
        {
            ToEntity = x => new User { Username = x.Username, Nickname = x.Nickname, AuthCode = x.AuthCode, };
        }
    }

    public class UserRegisterResponseModel
    {
        public static Func<User, UserRegisterResponseModel> FromEntity { get; set; }

        public string Nickname { get; set; }

        public string SessionKey { get; set; }

        static UserRegisterResponseModel()
        {
            FromEntity = x => new UserRegisterResponseModel { Nickname = x.Nickname, SessionKey = x.SessionKey, };
        }
    }

    public class UserLoginRequestModel
    {
        public static Func<UserLoginRequestModel, User> ToEntity { get; set; }

        public string Username { get; set; }

        public string AuthCode { get; set; }

        static UserLoginRequestModel()
        {
            ToEntity = x => new User { Username = x.Username, AuthCode = x.AuthCode, };
        }
    }

    public class UserLoginResponseModel
    {
        public static Func<User, UserLoginResponseModel> FromEntity { get; set; }

        public string Nickname { get; set; }

        public string SessionKey { get; set; }

        static UserLoginResponseModel()
        {
            FromEntity = x => new UserLoginResponseModel { Nickname = x.Nickname, SessionKey = x.SessionKey, };
        }
    }

    public class UserLogoutRequestModel
    {
        public string SessionKey { get; set; }
    }
}