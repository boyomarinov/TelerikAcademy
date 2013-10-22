using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Model;

namespace Forum.Services.Models
{
    public class ThreadRequestModel
    {
        public static Func<ThreadRequestModel, Thread> ToEntity { get; private set; }

        public ICollection<string> Categories { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
            
        public string Title { get; set; }

        static ThreadRequestModel()
        {
            ToEntity =
                thread =>
                    new Thread()
                    {
                        Title = thread.Title,
                        DateCreated = thread.DateCreated,
                        Content = thread.Content
                    };
        }
    }

    public class ThreadResponseModel
    {
        public static Func<Thread, ThreadResponseModel> FromEntity { get; private set; }

        public int Id { get; set; }

        public ICollection<PostResponseModel> Posts { get; private set; }

        public ICollection<string> Categories { get; private set; }

        public string CreatedBy { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string Title { get; set; }

        static ThreadResponseModel()
        {
            FromEntity =
                thread =>
                    new ThreadResponseModel
                    {
                        Id = thread.ThreadId,
                        Title = thread.Title,
                        DateCreated = thread.DateCreated,
                        Content = thread.Content,
                        CreatedBy = thread.CreatedByUser.Nickname,
                        Categories =
                            thread.Categories.Select(CategoryResponseModel.FromEntity).Select(x => x.Name).ToArray(),
                        Posts = thread.Posts.Select(PostResponseModel.FromEntity).ToArray()
                    };
        }
    }


}