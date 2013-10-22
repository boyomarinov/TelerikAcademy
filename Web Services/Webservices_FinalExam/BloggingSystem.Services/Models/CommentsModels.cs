using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using BloggingSystem.Model;

namespace BloggingSystem.Services.Models
{
    [DataContract]
    public class CommentInPostModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "commentedBy")]
        public string CommentedBy { get; set; }

        public static CommentInPostModel CreateCommentInPostModel(Comment comment)
        {
            CommentInPostModel toReturn = new CommentInPostModel()
            {
                Text = comment.Text,
                CommentedBy = comment.CommentedBy.Username,
                PostDate = comment.PostDate
            };

            return toReturn;
        }
    }
}