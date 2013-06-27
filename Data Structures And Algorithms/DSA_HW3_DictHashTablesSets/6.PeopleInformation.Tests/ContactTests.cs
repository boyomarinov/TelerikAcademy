using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _6.PeopleInformation.Tests
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void ContactEqualsFalseTest()
        {
            Contact first = new Contact("Pesho", "Sofia", "088123456");
            Contact second = new Contact("Jorko", "Plovdiv", "0888654321");
            bool equal = first.Equals(second);

            Assert.IsFalse(equal);
        }

        [TestMethod]
        public void ContactEqualsTrueTest()
        {
            Contact first = new Contact("Pesho", "Sofia", "088123456");
            Contact second = new Contact("Pesho", "Sofia", "088123456");
            bool equal = first.Equals(second);

            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void ContactEqualsDiffTownTest()
        {
            Contact first = new Contact("Pesho", "Sofia", "088123456");
            Contact second = new Contact("Pesho", "Plovdiv", "088123456");
            bool equal = first.Equals(second);

            Assert.IsFalse(equal);
        }

        [TestMethod]
        public void ContactEqualsMarginTest()
        {
            Contact first = new Contact("Pesho", "Sofia", "088123456");
            Contact second = new Contact("Pesho", "Sofia", "088123457");
            bool equal = first.Equals(second);

            Assert.IsFalse(equal);
        }
    }
}
