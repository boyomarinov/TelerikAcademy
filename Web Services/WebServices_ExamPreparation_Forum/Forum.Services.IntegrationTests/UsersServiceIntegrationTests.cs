using System.Collections.Generic;
using System.Net;
using System.Transactions;
using System.Web.Http;
using Forum.Model;
using Forum.Services.Controllers;
using Forum.Services.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SchoolSystem.Repositories;
using Telerik.JustMock;

namespace Forum.Services.IntegrationTests
{
    [TestClass]
    public class UsersServiceIntegrationTests
    {
        [TestClass]
        public class StudentsControllerIntegrationTests
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
                    new Route("DefaultApi", "api/{controller}/{action}/{id}", new
                    {
                        id = RouteParameter.Optional,
                    })
                };

                this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
            }

            [TestCleanup]
            public void TearDown()
            {
                tran.Dispose();
            }

            [TestMethod]
            public void GetAll_WhenDataInDatabase_ShouldReturnData()
            {
                httpServer.Get("api/threads");
            }

            [TestMethod]
            public void Register_WhenUserModelValid_ShouldSaveToDatabase()
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    UserRegisterRequestModel testUser = new UserRegisterRequestModel()
                    {
                        Username = "ValidUser",
                        Nickname = "validnick",
                        AuthCode = new string('b', 40)
                    };

                    var httpServer = new InMemoryHttpServer("http://localhost/");
                    var response = httpServer.Post("api/users/register", testUser);

                    Assert.AreEqual( HttpStatusCode.Created, response.StatusCode);
                    Assert.IsNotNull(response.Content);

                    var contentString = response.Content.ReadAsStringAsync().Result;
                    var model = JsonConvert.DeserializeObject<UserRegisterResponseModel>(contentString);
                    Assert.AreEqual(testUser.Nickname, model.Nickname);
                    Assert.IsNotNull(model.SessionKey);
                }
            }

            //[TestMethod]
            //public void Register_WhenUserModelValid_ShouldSaveToDatabase()
            //{
            //    var mockUserRepo = Mock.Create<IRepository<User>>();
            //    var usersList = new List<User>();


            //    var testUser = new UserRegisterRequestModel
            //    {
            //        Username = "VALIDUSER",
            //        Nickname = "VALIDNICK",
            //        AuthCode = new string('b', 40)
            //    };

            //    Mock.Arrange(() => mockUserRepo.Add(Arg.IsAny<User>()))
            //        .DoInstead<User>((x) =>
            //        {
            //            User userToadd = new User()
            //            {
            //                UserId = usersList.Count + 1,
            //                Username = x.Username,
            //                Nickname = x.Nickname,
            //                AuthCode = x.AuthCode
            //            };

            //            usersList.Add(userToadd);
            //        });

            //    Mock.Arrange(() => mockUserRepo.Update(Arg.IsAny<int>(), Arg.IsAny<User>()))
            //        .DoInstead<int, User>((i, user) => usersList[i].SessionKey = user.SessionKey);
                
            //    var model = this.RegisterTestUser(this.httpServer, testUser);

            //    Assert.AreEqual(testUser.Nickname, model.Nickname);
            //    Assert.IsNotNull(model.SessionKey);
            //}

            //[TestMethod]
            //public void GetAll_WhenDataInDatabase_ShouldReturnData()
            //{
            //    var testUser = new UserModel
            //    {
            //        Username = "VALIDUSER",
            //        Nickname = "VALIDNICK",
            //        AuthCode = new string('b', 40)
            //    };
            //    LoggedUserModel userModel = this.RegisterTestUser(this.httpServer, testUser);
            //    var headers = new Dictionary<string, string>();
            //    headers["X-sessionKey"] = userModel.SessionKey;
            //    var response = this.httpServer.Get("api/threads", headers);

            //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            //    Assert.IsNotNull(response.Content);
            //}

            private UserRegisterResponseModel RegisterTestUser(InMemoryHttpServer httpServer, UserRegisterRequestModel testUser)
            {
                var response = httpServer.Post("api/users/register", testUser);
                var contentString = response.Content.ReadAsStringAsync().Result;
                var userModel = JsonConvert.DeserializeObject<UserRegisterResponseModel>(contentString);

                return userModel;
            }
        }
    }
}
