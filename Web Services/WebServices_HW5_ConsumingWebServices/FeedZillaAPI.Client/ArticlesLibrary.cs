using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedZillaAPI.Client
{
    public class ArticlesLibrary
    {
        public HashSet<Article> Articles { get; set; }

        public string Description { get; set; }

        public string SyndicationUrl { get; set; }

        public string Title { get; set; }

        //public ArticlesLibrary(ICollection<Article> library, string description, string syndicationUrl, string title)
        //{
        //    this.Library = library;
        //    this.Description = description;
        //    this.SyndicationUrl = syndicationUrl;
        //    this.Title = title;
        //}
        public override string ToString()
        {
            return string.Format("Articles: {0}, Description: {1}, SyndicationUrl: {2}, Title: {3}", this.Articles, this.Description, this.SyndicationUrl, this.Title);
        }
    }
}
