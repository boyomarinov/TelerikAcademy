using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using BloggingSystem.Model;

namespace BloggingSystem.Services.Models
{
    public class PostRequestModel
    {
        public static Func<PostRequestModel, Post> ToEntity { get; private set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public ICollection<string> Tags { get; set; }

        static PostRequestModel()
        {
            ToEntity =
                x =>
                    new Post()
                    {
                        Text = x.Text,
                        Title = x.Title,
                    };
        }
    }


    public class PostResponseModel
    {
        public static Func<Post, PostResponseModel> FromEntity { get; private set; }

        public int Id { get; set; }

        public string Title { get; set; }

        static PostResponseModel()
        {
            FromEntity =
                x =>
                    new PostResponseModel
                    {
                        Id = x.PostId,
                        Title = x.Title
                    };
        }
    }

    [DataContract]
    public class PostResponseDetailedModel
    {
        public static Func<Post, PostResponseDetailedModel> FromEntity { get; private set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "tags")]
        public ICollection<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public ICollection<CommentInPostModel> Comments { get; set; }

        //static PostResponseDetailedModel()
        //{
        //    FromEntity =
        //        x =>
        //            new PostResponseDetailedModel
        //            {

        //                Id = x.PostId,
        //                Title = x.Title,
        //                Text = x.Text,
        //                PostedBy = x.PostedBy.Username,
        //                PostDate = x.PostDate,
        //                Comments = (from comment in x.Comments
        //                            select new CommentInPostModel()
        //                            {
        //                                Text = comment.Text,
        //                                CommentedBy = comment.CommentedBy.Username,
        //                                PostDate = comment.PostDate
        //                            }).ToList(),
        //                Tags = x.Tags.Select(y => y.Name).ToList()
        //            };
        //}
    }

}