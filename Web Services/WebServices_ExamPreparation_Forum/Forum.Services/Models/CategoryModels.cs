using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Model;

namespace Forum.Services.Models
{
    public class CategoryResponseModel
    {
        public static Func<Category, CategoryResponseModel> FromEntity { get; private set; }

        public string Name { get; set; }

        static CategoryResponseModel()
        {
            FromEntity = x => new CategoryResponseModel { Name = x.Name };
        }
    }
}