using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Animals
{
    class Kitten : Cat, ISound
    {
        public Kitten(int age, string name)
            : base(age, name, 'f')
        { }

        public void MakeSound()
        {
            Console.WriteLine("Miaaaauuuu!");
        }
    }
}
