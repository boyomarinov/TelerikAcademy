using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.EfficientProductSearch
{
    public class Product : IComparable
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public int CompareTo(Object other)
        {
            return (this.Price < ((Product)other).Price) ? -1 : ((this.Price > ((Product)other).Price) ? 1 : 0);
        }

        public override string ToString()
        {
            return String.Format("{0} {1:C}", this.Name, this.Price);
        }
    }
}
