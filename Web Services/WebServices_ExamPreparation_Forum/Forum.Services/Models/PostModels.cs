using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Model;

namespace Forum.Services.Models
{
    public class PostRequestModel
    {
        public static Func<PostRequestModel, Post> ToEntity { get; private set; }

        public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime? PostDate { get; set; }

        public double Rating { get; set; }

        public User PostedBy { get; set; }

        public Thread ForThread { get; set; }

        static PostRequestModel()
        {
            ToEntity =
                x =>
                    new Post()
                    {
                        PostId = x.PostId,
                        ForThread = x.ForThread,
                        Content = x.Content,
                        PostDate = x.PostDate.Value,
                        PostedByUser = x.PostedBy
                    };
        }
    }

    public class PostResponseModel
    {
        public static Func<Post, PostResponseModel> FromEntity { get; private set; }

        public string Content { get; set; }

        public DateTime? PostDate { get; set; }

        public double Rating { get; set; }

        public string PostedBy { get; set; }

        static PostResponseModel()
        {
            FromEntity =
                x =>
                    new PostResponseModel
                    {
                        Content = x.Content,
                        PostDate = x.PostDate,
                        Rating = (x.Votes.Count > 0) ? x.Votes.Average(v => v.Value) : 0,
                        PostedBy = x.PostedByUser.Nickname
                    };
        }
    }

}