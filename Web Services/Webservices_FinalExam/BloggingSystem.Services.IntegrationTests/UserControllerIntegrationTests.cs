using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;
using BloggingSystem.Services.Controllers;
using BloggingSystem.Services.Models;
using Forum.Services.IntegrationTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BloggingSystem.Services.IntegrationTests
{
    [TestClass]
    public class UserControllerIntegrationTests
    {
        private static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
                {
                     new Route("TagsApi", "api/tags/{action}", new
                    {
                        controller = "tags"
                    }),
                     new Route("PostCommentsApi", "api/posts/{Id}/{action}", new
                    {
                        controller = "posts"
                    }),
                     new Route("UserApi", "api/users/{action}", new
                    {
                        controller = "users"
                    }),
                    new Route("DefaultApi", "api/{controller}/{id}", new
                    {
                        id = RouteParameter.Optional,
                    }),
                };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void RegisterValidUserTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                {
                    Username = "ValidUser",
                    DisplayName = "validnick",
                    AuthCode = new string('b', 40)
                };

                var response = RegisterTestUser(httpServer, testUser);

                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
                Assert.IsNotNull(response.Content);
            }
        }

        [TestMethod]
        public void RegisterUserWithShorterAuthCodeTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                {
                    Username = "ValidUser",
                    DisplayName = "validnick",
                    AuthCode = new string('b', 39)
                };

                var response = RegisterTestUser(httpServer, testUser);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [TestMethod]
        public void RegisterUserWithAuthCodeMissingTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                {
                    Username = "ValidUser",
                    DisplayName = "validnick",
                };

                var response = RegisterTestUser(httpServer, testUser);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [TestMethod]
        public void RegisterUserWithoutUsernameTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                {
                    DisplayName = "validnick",
                    AuthCode = new string('b', 39)
                };

                var response = RegisterTestUser(httpServer, testUser);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [TestMethod]
        public void RegisterUserWithoutDisplayNameTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                {
                    Username = "ValidUser",
                    AuthCode = new string('b', 39)
                };

                var response = RegisterTestUser(httpServer, testUser);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [TestMethod]
        public void RegisterAlreadyExistingUserTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                {
                    Username = "ValidUser",
                    DisplayName = "validnick",
                    AuthCode = new string('b', 40)
                };

                var response = RegisterTestUser(httpServer, testUser);
                var existingUserResponse = RegisterTestUser(httpServer, testUser);

                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
                Assert.AreEqual(HttpStatusCode.BadRequest, existingUserResponse.StatusCode);
            }
        }

        [TestMethod]
        public void RegisterUserWithInvalidUsernameTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                {
                    Username = "ValidUser*^&as12#",
                    DisplayName = "validnick",
                    AuthCode = new string('b', 40)
                };

                var response = RegisterTestUser(httpServer, testUser);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [TestMethod]
        public void RegisterUserWithInvalidDisplayNameTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                {
                    Username = "ValidUser",
                    DisplayName = "validn^7ic(k",
                    AuthCode = new string('b', 40)
                };

                var response = RegisterTestUser(httpServer, testUser);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [TestMethod]
        public void RegisterUserWithLongerAuthCodeTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                {
                    Username = "ValidUser",
                    DisplayName = "validnick",
                    AuthCode = new string('b', 41)
                };

                var response = RegisterTestUser(httpServer, testUser);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [TestMethod]
        public void LoginValidUserTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserLoginRequestModel testUser = new UserLoginRequestModel()
                {
                    Username = "DonchoMinkov",
                    AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                };

                var response = LoginTestUser(httpServer, testUser);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.IsNotNull(response.Content);
            }
        }



        [TestMethod]
        public void LogoutValidUserTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                {
                    Username = "ValidUser",
                    DisplayName = "validnick",
                    AuthCode = new string('b', 40)
                };

                UserRegisterResponseModel userModel = RegisterTestUserWithSKey(httpServer, testUser);
                var headers = new Dictionary<string, string>();
                headers["X-sessionKey"] = userModel.SessionKey;

                UserLogoutRequestModel logoutModel = new UserLogoutRequestModel()
                {
                    SessionKey = userModel.SessionKey
                };
                var response = this.LogoutTestUser(httpServer, logoutModel, headers);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.IsNotNull(response.Content);
            }
        }
        

        private HttpResponseMessage RegisterTestUser(InMemoryHttpServer httpServer, UserRegisterRequestModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<UserRegisterResponseModel>(contentString);

            return response;
        }

        private UserRegisterResponseModel RegisterTestUserWithSKey(InMemoryHttpServer httpServer, UserRegisterRequestModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<UserRegisterResponseModel>(contentString);

            return userModel;
        }

        private HttpResponseMessage LoginTestUser(InMemoryHttpServer httpServer, UserLoginRequestModel testModel)
        {
            var response = httpServer.Post("api/users/login", testModel);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<UserRegisterResponseModel>(contentString);

            return response;
        }

        private HttpResponseMessage LogoutTestUser(InMemoryHttpServer httpServer, UserLogoutRequestModel userLogoutModel, Dictionary<string, string> headers)
        {
            var response = httpServer.Put("api/users/logout", userLogoutModel, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<UserRegisterResponseModel>(contentString);

            return response;
        }
    }
}
