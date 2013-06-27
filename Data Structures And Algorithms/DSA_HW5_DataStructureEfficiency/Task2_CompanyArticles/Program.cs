using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task2_CompanyArticles
{
    public static class Program
    {
        private static OrderedMultiDictionary<double, Article> articlesByPrice =
            new OrderedMultiDictionary<double, Article>(true);

        public static List<Article> GetProductsInRange(double min, double max)
        {
            var matched = articlesByPrice.Range(min, true, max, true);
            List<Article> result = new List<Article>();

            foreach (var keyValuePair in matched)
            {
                result.AddRange(keyValuePair.Value);
            }

            return result;
        }

        public static void Main()
        {
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                double price = rand.Next(1, 10000)*1.4;
                Article current = new Article("Title" + i, "Vendor" + i, "Barcode" + i, price);
                articlesByPrice.Add(current.Price, current);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var article in GetProductsInRange(150, 400))
            {
                sb.AppendLine(article.ToString());
            }

            Console.Write(sb);
        }
    }
}
