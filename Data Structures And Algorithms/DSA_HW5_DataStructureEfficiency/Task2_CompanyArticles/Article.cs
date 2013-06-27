using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_CompanyArticles
{
    public class Article : IComparable<Article>
    {
        public string Title { get; set; }
        public string Vendor { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }

        public Article(string title, string vendor, string barcode, double price)
        {
            Title = title;
            Vendor = vendor;
            Barcode = barcode;
            Price = price;
        }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", this.Title, this.Vendor, this.Barcode, this.Price);
        }
    }
}
