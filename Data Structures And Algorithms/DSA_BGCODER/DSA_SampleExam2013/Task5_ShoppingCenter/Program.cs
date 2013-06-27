using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task5_ShoppingCenter
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Producer { get; set; }

        public Product(string name, double price, string producer)
        {
            Name = name;
            Price = price;
            Producer = producer;
        }

        public int CompareTo(Product other)
        {
            int byName = this.Name.CompareTo(other.Name);
            if (byName == 0)
            {
                int ByPrice = this.Price.CompareTo(other.Price);
                if (ByPrice == 0)
                {
                    return this.Producer.CompareTo(other.Producer);
                }
                else
                {
                    return ByPrice;
                }
            }
            else
            {
                return byName;
            }
            //return this.ToString().CompareTo(other.ToString());
            //return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return "{" + this.Name + ";" + this.Producer + ";" + this.Price.ToString("F2") + "}";
        }
    }

    public static class Program
    {
        private static MultiDictionary<string, Product> byName = new MultiDictionary<string, Product>(true);

        private static OrderedMultiDictionary<double, Product> byPrice =
            new OrderedMultiDictionary<double, Product>(true, (d, d1) => d.CompareTo(d1), (product, product1) => 0);

        private static MultiDictionary<string, Product> byProducer =
            new MultiDictionary<string, Product>(true);

        private static MultiDictionary<Tuple<string, string>, Product> byNameAndProducer =
            new MultiDictionary<Tuple<string, string>, Product>(true);

        public static int DeleteProduct(string name, string producer)
        {
            var tuple = new Tuple<string, string>(name, producer);

            var productsToDelete = byNameAndProducer[tuple];

            int count = productsToDelete.Count;
            foreach (var product in productsToDelete)
            {
                byName[product.Name].Remove(product);
                byPrice[product.Price].Remove(product);
                byProducer[product.Producer].Remove(product);
            }

            byNameAndProducer.Remove(tuple);

            return count;
        }

        public static int DeleteProducer(string producer)
        {
            var productsByProducer = byProducer[producer];

            int count = productsByProducer.Count;
            foreach (var product in productsByProducer)
            {
                byName.Remove(product.Name);
                byPrice.Remove(product.Price);
                //byProducer.Remove(product.Producer);
                byNameAndProducer.Remove(new Tuple<string, string>(product.Name, product.Producer));
            }

            byProducer.Remove(producer);

            return count;
        }

        public static IEnumerable<Product> FindProductsByName(string name)
        {
            return byName[name].OrderBy(x => x);
        }

        public static IEnumerable<Product> FindProductsByPriceRange(double from, double to)
        {
            var productsInRange = byPrice.Range(from, true, to, true).Values;

            return productsInRange.OrderBy(x => x);
        }

        public static IEnumerable<Product> FindProductsByProducer(string producer)
        {
            return byProducer[producer].OrderBy(x => x);
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../test.005.in.txt"));
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Debug.Listeners.Add(new ConsoleTraceListener());
#endif


            Stopwatch sw = new Stopwatch();
            sw.Start();
            StringBuilder sb = new StringBuilder();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string line = Console.ReadLine();
                string[] splitted = line.Split(new char[] { ' ' }, 2);
                string command = splitted[0];
                string[] commandParams = splitted[1].Split(';');

                Product currentProduct;

#if DEBUG
                sb.AppendLine();
                sb.AppendLine(line);
#endif

                switch (command)
                {
                    case "AddProduct":
                        currentProduct = new Product(commandParams[0], double.Parse(commandParams[1]), commandParams[2]);
                        byName.Add(commandParams[0], currentProduct);
                        byPrice.Add(double.Parse(commandParams[1]), currentProduct);
                        byProducer.Add(commandParams[2], currentProduct);
                        byNameAndProducer.Add(new Tuple<string, string>(commandParams[0], commandParams[2]), currentProduct);

                        sb.AppendLine("Product added");

                        break;

                    case "DeleteProducts":
                        if (commandParams.Length > 1)
                        {
                            int deletedProds = DeleteProduct(commandParams[0], commandParams[1]);
                            if (deletedProds == 0)
                            {
                                sb.AppendLine("No products found");
                            }
                            else
                            {
                                sb.AppendLine(deletedProds + " products deleted");
                            }

                        }
                        else
                        {
                            int deletedProds = DeleteProducer(commandParams[0]);
                            if (deletedProds == 0)
                            {
                                sb.AppendLine("No products found");
                            }
                            else
                            {
                                sb.AppendLine(deletedProds + " products deleted");
                            }
                        }

                        break;

                    case "FindProductsByName":
                        var matchedProdByName = FindProductsByName(commandParams[0]);
                        if (!matchedProdByName.Any())
                        {
                            sb.AppendLine("No products found");
                        }
                        else
                        {
                            foreach (var product in matchedProdByName)
                            {
                                sb.AppendLine(product.ToString());
                            }
                        }

                        break;

                    case "FindProductsByProducer":
                        var matchedProdByProducer = FindProductsByProducer(commandParams[0]);
                        if (!matchedProdByProducer.Any())
                        {
                            sb.AppendLine("No products found");
                        }
                        else
                        {
                            foreach (var product in matchedProdByProducer)
                            {
                                sb.AppendLine(product.ToString());
                            }
                        }

                        break;

                    case "FindProductsByPriceRange":
                        var matchedProdByPrice = FindProductsByPriceRange(double.Parse(commandParams[0]), double.Parse(commandParams[1]));
                        if (!matchedProdByPrice.Any())
                        {
                            sb.AppendLine("No products found");
                        }

                        foreach (var product in matchedProdByPrice)
                        {
                            sb.AppendLine(product.ToString());
                        }

                        break;

                    default:
                        throw new InvalidOperationException("Invalid command!");
                }
            }

#if !DEBUG
            Console.Write(sb.ToString());
#endif
            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }
    }
}
