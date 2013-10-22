using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Http;
using BloggingSystem.Model;
using BloggingSystem.Services.Controllers;
using BloggingSystem.Services.Models;
using Forum.Services.IntegrationTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BloggingSystem.Services.IntegrationTests
{
    /// <summary>
    /// Summary description for PostsControllerIntegrationTests
    /// </summary>
    [TestClass]
    public class PostsControllerIntegrationTests
    {
        private static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(PostsController);
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
        public void GetPostsTest()
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

            PostResponseDetailedModel postModel = new PostResponseDetailedModel()
            {
                Title = "Test Post Title",
                Tags = new List<string>(),
                Text = "Basdlksdflksdfsdlfkj"
            };

            var response = CreatePost(httpServer, postModel, headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetPostsbyTagsTest()
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

            PostResponseDetailedModel postModel = new PostResponseDetailedModel()
            {
                Title = "Test Post Title",
                Tags = new List<string>() {"web"},
                Text = "Basdlksdflksdfsdlfkj"
            };

            var createPostResponse = CreatePost(httpServer, postModel, headers);
            var getResponse = GetPostsByTags(httpServer, postModel, headers);

            Assert.AreEqual(HttpStatusCode.OK, createPostResponse.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
        }

        [TestMethod]
        public void MakeACommentForPostTest()
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

            PostResponseDetailedModel postModel = new PostResponseDetailedModel()
            {
                Title = "Test Post Title",
                Tags = new List<string>() { "web" },
                Text = "Basdlksdflksdfsdlfkj"
            };

            CommentInPostModel commentModel = new CommentInPostModel()
            {
                Text = "Mocking is nice!"
            };

            var returnedModel = CreatePostAndReturnModel(httpServer, postModel, headers);
            var getResponse = MakeCommentForPost(httpServer, returnedModel.Id, commentModel, headers);

            Assert.AreEqual(HttpStatusCode.Created, getResponse.StatusCode);
        }

        private UserRegisterResponseModel RegisterTestUserWithSKey(InMemoryHttpServer httpServer, UserRegisterRequestModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<UserRegisterResponseModel>(contentString);

            return userModel;
        }

        private HttpResponseMessage CreatePost(InMemoryHttpServer httpServer, PostResponseDetailedModel postModel, Dictionary<string, string> headers)
        {
            var response = httpServer.Post("api/posts", postModel, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            //var postModel = JsonConvert.DeserializeObject<PostResponseDetailedModel>(contentString);

            return response;
        }

        private PostResponseDetailedModel CreatePostAndReturnModel(InMemoryHttpServer httpServer, PostResponseDetailedModel postModel, Dictionary<string, string> headers)
        {
            var response = httpServer.Post("api/posts", postModel, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var returnedPostModel = JsonConvert.DeserializeObject<PostResponseDetailedModel>(contentString);

            return returnedPostModel;
        }

        private HttpResponseMessage GetPostsByTags(InMemoryHttpServer httpServer, PostResponseDetailedModel postModel, Dictionary<string, string> headers)
        {
            var response = httpServer.Post("api/posts?tags=web", postModel, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            //var userModel = JsonConvert.DeserializeObject<PostResponseDetailedModel>(contentString);

            return response;
        }

         private HttpResponseMessage MakeCommentForPost(InMemoryHttpServer httpServer, int postId, CommentInPostModel commentModel, Dictionary<string, string> headers)
        {
            var response = httpServer.Put("api/posts/" + postId + "/comment", commentModel, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            //var returnedPostModel = JsonConvert.DeserializeObject<PostResponseDetailedModel>(contentString);

            return response;
        }
    }
}
