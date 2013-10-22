using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Forum.Model;
using Forum.Services.Data;
using Forum.Services.Models;
using Forum.Services.Utilities;

namespace Forum.Services.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        [HttpPost]
        [ActionName("login")]
        public UserLoginResponseModel Login([FromBody] UserLoginRequestModel userModel)
        {
            var responseMessage = this.TryExecuteOperation(() =>
            {
                var user = this.unitOfWork.userRepository.All().SingleOrDefault(x => x.AuthCode == userModel.AuthCode);
                if (user == null)
                {
                    throw new ArgumentException("User is not registered!");
                }

                if (user.SessionKey == null)
                {
                    user.SessionKey = SessionGenerator.GenerateSessionKey(user.UserId);
                    this.unitOfWork.userRepository.Update(user.UserId, user);
                }

                return UserLoginResponseModel.FromEntity(user);
            });

            return responseMessage;
        }

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage Register([FromBody] UserRegisterRequestModel userModel)
        {
            var responseMessage = this.TryExecuteOperation(() =>
            {
                User user = UserRegisterRequestModel.ToEntity(userModel);
                UserValidator.ValidateUsername(user.Username);
                UserValidator.ValidateNickname(user.Nickname);
                UserValidator.ValidateAuthCode(user.AuthCode);

                this.unitOfWork.userRepository.Add(user);
                user.SessionKey = SessionGenerator.GenerateSessionKey(user.UserId);
                this.unitOfWork.userRepository.Update(user.UserId, user);

                return this.Request.CreateResponse(HttpStatusCode.Created, UserRegisterResponseModel.FromEntity(user));
            });

            return responseMessage;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage Logout([FromBody] UserLogoutRequestModel userModel)
        {
            var messageResponse = this.TryExecuteOperation(() =>    
            {
                var user =
                    this.unitOfWork.userRepository.All().SingleOrDefault(x => x.SessionKey == userModel.SessionKey);
                if (user == null)
                {
                    throw new ArgumentException("User is missing or not logged in!");
                }

                user.SessionKey = null;
                this.unitOfWork.userRepository.Update(user.UserId, user);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            });

            return messageResponse;
        }
    }
}
