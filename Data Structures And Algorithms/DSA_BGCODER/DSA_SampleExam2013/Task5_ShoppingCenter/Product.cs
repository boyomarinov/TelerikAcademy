//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Task5_ShoppingCenter
//{
//    public class Product : IComparable<Product>
//    {
//        public string Name { get; set; }

//        public double Price { get; set; }

//        public string Producer { get; set; }

//        public Product(string name, double price, string producer)
//        {
//            Name = name;
//            Price = price;
//            Producer = producer;
//        }

//        public int CompareTo(Product other)
//        {
//            int byName = this.Name.CompareTo(other.Name);
//            if (byName == 0)
//            {
//                int ByPrice = this.Price.CompareTo(other.Price);
//                if (ByPrice == 0)
//                {
//                    return this.Producer.CompareTo(other.Producer);
//                }
//                else
//                {
//                    return ByPrice;
//                }
//            }
//            else
//            {
//                return byName;
//            }
//        }

//        public override string ToString()
//        {
//            return "{" +  this.Name + ";" +  this.Producer + ";" + this.Price + "}";
//        }
//    }
//}
