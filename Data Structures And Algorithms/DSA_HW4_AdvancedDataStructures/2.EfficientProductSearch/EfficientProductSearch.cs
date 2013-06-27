using System;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;
using System.Diagnostics;
using System.Collections.Generic;

namespace _2.EfficientProductSearch
{
    public class EfficientProductSearch
    {
        public const int MIN_RANGE = 1;
        public const int MAX_RANGE = 1000;

        public static void GenerateProductsListFile(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            Random rand = new Random();
            using (sw)
            {
                for (int i = 1; i < 500001; i++)
                {
                    sw.WriteLine("Product{0} {1}", i, rand.Next(MIN_RANGE, MAX_RANGE));
                }
            }
        }

        public static void Main()
        {
            GenerateProductsListFile("../../ProductList.txt");

            Console.WriteLine("Give price interval start [bigger than {0}]", MIN_RANGE);
            double start = double.Parse(Console.ReadLine());
            Console.WriteLine("Give price interval end [smaller than {0}]", MAX_RANGE);
            double end = double.Parse(Console.ReadLine());

            ProductsList products = new ProductsList();
            products.ReadProductsList("../../ProductList.txt");
            List<Product> bestProducts = products.GetBestProductsInRange(start, end, 20);

            foreach (var item in bestProducts)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
