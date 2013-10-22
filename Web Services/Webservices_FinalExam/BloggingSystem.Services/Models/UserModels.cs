using System;
using System.Runtime.Serialization;
using BloggingSystem.Model;

namespace BloggingSystem.Services.Models
{
    public class UserRegisterRequestModel
    {
        public static Func<UserRegisterRequestModel, User> ToEntity { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string AuthCode { get; set; }

        static UserRegisterRequestModel()
        {
            ToEntity = x => new User { Username = x.Username, DisplayName = x.DisplayName, AuthCode = x.AuthCode, };
        }
    }

    [DataContract]
    public class UserRegisterResponseModel
    {
        public static Func<User, UserRegisterResponseModel> FromEntity { get; set; }

        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        static UserRegisterResponseModel()
        {
            FromEntity = x => new UserRegisterResponseModel { DisplayName = x.DisplayName, SessionKey = x.SessionKey, };
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

    [DataContract]
    public class UserLoginResponseModel
    {
        public static Func<User, UserLoginResponseModel> FromEntity { get; set; }

        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        static UserLoginResponseModel()
        {
            FromEntity = x => new UserLoginResponseModel { DisplayName = x.DisplayName, SessionKey = x.SessionKey, };
        }
    }

    public class UserLogoutRequestModel
    {
        public string SessionKey { get; set; }
    }
}