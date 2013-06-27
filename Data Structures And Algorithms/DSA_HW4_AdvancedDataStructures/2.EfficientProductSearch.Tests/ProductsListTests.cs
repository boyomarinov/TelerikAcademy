using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2.EfficientProductSearch.Tests
{
    [TestClass]
    public class ProductsListTests
    {
        [TestMethod]
        public void ConstructorCountTest()
        {
            ProductsList products = new ProductsList();
            products.ReadProductsList("../../../2.EfficientProductSearch/ProductList.txt");

            Assert.AreEqual(500000, products.Count);
        }

        [TestMethod]
        public void RangeStressTest()
        {
            ProductsList products = new ProductsList();
            products.ReadProductsList("../../../2.EfficientProductSearch/ProductList.txt");
            Random rand = new Random();

            for (int i = 0; i < 50000; i++)
            {
                int start = rand.Next(2, 400);
                int end = rand.Next(500, 999);
                int count = rand.Next(10, 80);
                products.GetBestProductsInRange(start, end, count);
            }
        }
    }
}
