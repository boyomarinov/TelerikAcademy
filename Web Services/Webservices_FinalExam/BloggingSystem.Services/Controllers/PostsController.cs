using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using System.Web.Providers.Entities;
using System.Web.UI.WebControls;
using BloggingSystem.Model;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.Data;
using BloggingSystem.Services.Models;

namespace BloggingSystem.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [HttpPost]
        public HttpResponseMessage CreatePost([FromBody] PostRequestModel postModel
, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<HttpResponseMessage>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var postToAdd = new Post()
                {
                    Title = postModel.Title,
                    PostDate = DateTime.Now,
                    Text = postModel.Text,
                    PostedBy = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey),
                };

                foreach (var tagName in postModel.Tags)
                {
                    var tag = unitOfWork.tagRepository.All().FirstOrDefault(x => x.Name == tagName);
                    if (tag == null)
                    {
                        Tag toAdd = new Tag()
                        {
                            Name = tagName
                        };
                        postToAdd.Tags.Add(toAdd);
                    }

                    postToAdd.Tags.Add(tag);
                }
                //postToAdd.PostedBy = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                unitOfWork.postRepository.Add(postToAdd);

                return Request.CreateResponse(HttpStatusCode.OK, PostResponseModel.FromEntity(postToAdd));
            });

            return messageResponse;
        }

        [HttpGet]
        public IEnumerable<PostResponseDetailedModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<PostResponseDetailedModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var matchedPosts = unitOfWork.postRepository.All().ToList();
                var postModels = matchedPosts.Select(post => new PostResponseDetailedModel()
                {
                    Id = post.PostId,
                    Title = post.Title,
                    Text = post.Text,
                    PostedBy = post.PostedBy.Username,
                    PostDate = post.PostDate,
                    Comments = post.Comments.Select(c => new CommentInPostModel()
                                                        {
                                                            Text = c.Text,
                                                            CommentedBy = c.CommentedBy.Username,
                                                            PostDate = c.PostDate
                                                        }).ToList(),
                    
                    Tags = post.Tags.Select(x => x.Name).ToList()
                });
                    
                return postModels.OrderByDescending(x => x.PostDate); //matchedPosts.Select(PostResponseDetailedModel.FromEntity);
            });

            return messageResponse;
        }

        [HttpGet]
        public IEnumerable<PostResponseDetailedModel> GetByPage([FromUri] int page, [FromUri] int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<PostResponseDetailedModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var allThreadsCount = unitOfWork.postRepository.All().Count();
                if (allThreadsCount < page * count) //TODO: || allThreadsCount >= (page + 1) * count )
                {
                    throw new ArgumentException("No such page!");
                }

                var matchedThreads = unitOfWork.postRepository.All().ToList().Skip(page * count).Take(count);

                return matchedThreads.Select(PostResponseDetailedModel.FromEntity);
            });

            return messageResponse;
        }

        [HttpGet]
        public IEnumerable<PostResponseDetailedModel> GetPostsByKeyword([FromUri] string keyword,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<PostResponseDetailedModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var matchedPosts = unitOfWork.postRepository.All()
                                             .Where(x => x.Title.ToLower().Contains(keyword.ToLower()));

                return matchedPosts.Select(PostResponseDetailedModel.FromEntity);
            });

            return messageResponse;
        }

        [HttpGet]
        public IEnumerable<PostResponseDetailedModel> GetPostsByTags([FromUri] string tags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<PostResponseDetailedModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                string[] splittedTags = tags.Split(',');

                var allPosts = this.GetAll(sessionKey);
                var matchedPosts = allPosts.Where(x => x.Tags.Intersect(splittedTags).Count() == splittedTags.Count());

                return matchedPosts;
            });

            return messageResponse;
        }

        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage GetPosts(int Id, [FromBody] CommentInPostModel commentModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var messageResponse = this.TryExecuteOperation<HttpResponseMessage>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var matchedPost = unitOfWork.postRepository.All().SingleOrDefault(x => x.PostId == Id);
                if (matchedPost == null)
                {
                    throw new ArgumentException("The thread does not exist!");
                }

                Comment commentToAdd = new Comment()
                {
                    Text = commentModel.Text,
                    PostDate = DateTime.Now,
                    CommentedBy = user
                };

                matchedPost.Comments.Add(commentToAdd);

                this.unitOfWork.postRepository.Update(matchedPost.PostId, matchedPost);

                return Request.CreateResponse(HttpStatusCode.Created, PostResponseModel.FromEntity(matchedPost));
            });

            return messageResponse;
        }
    }
}
