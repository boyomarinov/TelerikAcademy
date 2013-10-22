using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace FeedZillaAPI.Client
{
    public static class Client
    {
        private static ArticlesLibrary GetAllArticles(HttpClient httpClient)
        {
            var response = httpClient.GetAsync("articles/search.json").Result;
            ArticlesLibrary library = response.Content.ReadAsAsync<ArticlesLibrary>().Result;

            return library;
        }

        private static ArticlesLibrary GetMatchedArticles(HttpClient httpClient, string searchString, int count)
        {
            var response = httpClient.GetAsync("articles/search.json?q=" + searchString + "&count=" + count).Result;
            ArticlesLibrary library = response.Content.ReadAsAsync<ArticlesLibrary>().Result;

            return library;
        }

        private static void PrintArticles(ArticlesLibrary library)
        {
            foreach (var article in library.Articles)
            {
                //Console.WriteLine(article.ToString());
                Console.WriteLine("Title: {0}\nURL: {1}", article.Title, article.Url);
                Console.WriteLine();
            }
        }

        public static void Main()
        {
            //http://api.feedzilla.com/v1/articles/search.json?q=Michael&count=1
            var feedzillaClient = new HttpClient();
            feedzillaClient.BaseAddress = new Uri("http://api.feedzilla.com/v1/");

            Console.Write("Search query: ");
            string queryString = Console.ReadLine();
            Console.Write("Count: ");
            int count = int.Parse(Console.ReadLine());

            PrintArticles(GetMatchedArticles(feedzillaClient, queryString, count));
            
            //Get all articles from feed
            //ArticlesLibrary articleLibrary = GetAllArticles(feedzillaClient);
            //PrintArticles(articleLibrary);

            //Get matching articles from feed
            //ArticlesLibrary matchedArticleLibrary = GetMatchedArticles(feedzillaClient, "Analysis", 2);
            //PrintArticles(matchedArticleLibrary);
        }
    }
}
