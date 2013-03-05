using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Animals
{
    abstract public class Animal
    {
        private int age;
        private string name;
        private char sex;

        public Animal(int age, string name, char sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public char Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public string GetTypeOfAnimal()
        {
            string type = this.GetType().ToString();
            string[] splitted = type.Split('.');

            return splitted[splitted.Length - 1];
        }

        public override string ToString()
        {
            return String.Format("{0}\nName: {1}\nAge: {2}\nSex: {3}",
                this.GetTypeOfAnimal(), this.name, this.age, this.sex);
        }

        public void MakeItTalk()
        {
            string castTo = this.GetTypeOfAnimal();
            
        }
    }
}
