using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace _2.EfficientProductSearch
{
    public class ProductsList
    {
        private OrderedBag<Product> products;

        public ProductsList()
        {
            this.products = new OrderedBag<Product>();
        }

        public int Count
        {
            get
            {
                return this.products.Count();
            }
        }

        public List<Product> GetBestProductsInRange(double start, double end, int productsCount)
        {
            var matched = this.products.Range(new Product(" ", start), true, new Product(" ", end), true).ToArray();
            List<Product> result = new List<Product>();

            int count = 0;
            foreach (var item in matched)
            {
                result.Add(item);
                count++;

                if (count > productsCount)
                {
                    break;
                }
            }

            return result;
        }

        public void ReadProductsList(string path)
        {
            StreamReader reader = new StreamReader(path);

            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] parsedProduct = line.Split(' ');
                    string name = parsedProduct[0].Trim();
                    double price = double.Parse(parsedProduct[1].Trim());
                    Product currentProduct = new Product(name, price);
                    this.products.Add(currentProduct);

                    line = reader.ReadLine();
                }
            }
        }

    }
}
