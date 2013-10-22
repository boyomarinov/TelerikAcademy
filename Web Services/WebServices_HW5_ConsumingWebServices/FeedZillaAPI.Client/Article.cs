using System;
using System.Collections.Generic;
using System.Linq;


namespace FeedZillaAPI.Client
{
    public class Article
    {
        public DateTime PublishDate { get; set; }

        public string Source { get; set; }

        public string SourceUrl { get; set; }

        public string Summary { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public Article(DateTime publishDate, string source, string sourceUrl, string summary, string title, string url)
        {
            this.PublishDate = publishDate;
            this.Source = source;
            this.SourceUrl = sourceUrl;
            this.Summary = summary;
            this.Title = title;
            this.Url = url;
        }

        public override string ToString()
        {
            return string.Format("PublishDate: {0}\nSource: {1}\nSourceUrl: {2}\nSummary: {3}\nTitle: {4}\nUrl: {5}\n", this.PublishDate.ToString(), this.Source, this.SourceUrl, this.Summary, this.Title, this.Url);
        }
    }

}

