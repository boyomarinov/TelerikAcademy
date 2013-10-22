using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using System.Web.UI.WebControls;
using Forum.Model;
using Forum.Services.Data;
using Forum.Services.Models;
using Forum.WebAPI.Attributes;

namespace Forum.Services.Controllers
{
    public class ThreadsController : BaseApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage Get([FromBody] ThreadRequestModel threadModel, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<HttpResponseMessage>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var threadToAdd = ThreadRequestModel.ToEntity(threadModel);
                threadToAdd.Categories = threadModel.Categories
                    .Select(x => unitOfWork.categoryRepository.All().Single(y => y.Name == x)).ToList();
                threadToAdd.CreatedByUser = user;

                unitOfWork.threadRepository.Add(threadToAdd);

                return Request.CreateResponse(HttpStatusCode.Created, ThreadResponseModel.FromEntity(threadToAdd));
            });

            return messageResponse;
        }

        [HttpGet]
        public IEnumerable<ThreadResponseModel> Get(
            [ValueProvider(typeof (HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<ThreadResponseModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var matchedThreads = unitOfWork.threadRepository.All();

                return matchedThreads.Select(ThreadResponseModel.FromEntity);
            });

            return messageResponse;
        }

        [HttpGet]
        public IEnumerable<ThreadResponseModel> Get([FromUri] string category, 
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<ThreadResponseModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var matchedThreads = unitOfWork.threadRepository.All().Where(x => x.Categories.Any(y => y.Name == category));

                return matchedThreads.Select(ThreadResponseModel.FromEntity);
            });

            return messageResponse;
        }

        [HttpGet]
        public IEnumerable<ThreadResponseModel> Get([FromUri] int page, [FromUri] int count, 
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<ThreadResponseModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var allThreadsCount = unitOfWork.threadRepository.All().Count();
                if (allThreadsCount < page * count) //TODO: || allThreadsCount >= (page + 1) * count )
                {
                    throw new ArgumentException("No such page!");
                } 

                var matchedThreads = unitOfWork.threadRepository.All().ToList().Skip(page*count).Take(count);

                return matchedThreads.Select(ThreadResponseModel.FromEntity);
            });

            return messageResponse;
        }

        [HttpGet]
        [ActionName("posts")]
        public IEnumerable<PostResponseModel> GetPosts(int threadId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<PostResponseModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var matchedThreads = unitOfWork.threadRepository.All().SingleOrDefault(x => x.ThreadId == threadId);
                if (matchedThreads == null)
                {
                    throw new ArgumentException("The thread does not exist!");
                }

                return matchedThreads.Posts.Select(PostResponseModel.FromEntity);
            });

            return messageResponse;
        }
    }
}
