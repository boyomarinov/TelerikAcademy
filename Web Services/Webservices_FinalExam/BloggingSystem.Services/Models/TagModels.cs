using System;
using System.Runtime.Serialization;
using BloggingSystem.Model;

namespace BloggingSystem.Services.Models
{
    [DataContract]
    public class TagResponseModel
    {
        public static Func<Tag, TagResponseModel> FromEntity { get; private set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "posts")]
        public int Posts { get; set; }

        static TagResponseModel()
        {
            FromEntity = x => new TagResponseModel { Id=x.Id, Name = x.Name, Posts = x.Posts.Count };
        }
    }
}