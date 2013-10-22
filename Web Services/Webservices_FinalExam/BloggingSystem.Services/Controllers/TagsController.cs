using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.Data;
using BloggingSystem.Services.Models;

namespace BloggingSystem.Services.Controllers
{
    public class TagsController : BaseApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [HttpGet]
        public IEnumerable<TagResponseModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {


            var messageResponse = this.TryExecuteOperation<IEnumerable<TagResponseModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var tags = this.unitOfWork.tagRepository.All().OrderBy(x => x.Id)
                               .Select(x => new TagResponseModel()
                               {
                                   Id = x.Id,
                                   Name = x.Name,
                                   Posts = x.Posts.Count
                               });

                return tags;
            });

            return messageResponse;
        }
    }
}
