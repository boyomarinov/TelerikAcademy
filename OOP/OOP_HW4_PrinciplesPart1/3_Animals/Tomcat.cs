using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Animals
{
    class Tomcat : Cat, ISound
    {
        public Tomcat(int age, string name)
            : base(age, name, 'm')
        { }

        public void MakeSound()
        {
            Console.WriteLine("Purrrrrrr!");
        }
    }
}
