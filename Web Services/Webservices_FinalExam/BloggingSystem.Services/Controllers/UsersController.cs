using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloggingSystem.Model;
using BloggingSystem.Services.Data;
using BloggingSystem.Services.Models;
using BloggingSystem.Services.Utilities;

namespace BloggingSystem.Services.Controllers
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
                UserValidator.ValidateNickname(user.DisplayName);
                UserValidator.ValidateAuthCode(user.AuthCode);

                var doesUserExist =
                    unitOfWork.userRepository.All()
                              .FirstOrDefault(
                                              x =>
                                              x.Username.ToLower() == user.Username.ToLower() ||
                                              x.DisplayName.ToLower() == user.DisplayName.ToLower());
                if (doesUserExist != null)
                {
                    throw new InvalidOperationException("User already exist in the database!");
                }

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

                return this.Request.CreateResponse(HttpStatusCode.OK, user);
            });

            return messageResponse;
        }
    }
}
