using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _6.PeopleInformation.Tests
{
    [TestClass]
    public class PhoneBookTests
    {
        [TestMethod]
        public void AddEntriesTest()
        {
            PhoneBook book = new PhoneBook();
            book.AddContact(new Contact("Jorko Barborko", "Dupnica", "088123456"));
            book.AddContact(new Contact("Jorko Barborko", "Dupnica", "088123458"));
            book.AddContact(new Contact("Jorko Barborko", "Sofia", "088123456"));

            Assert.AreEqual(3, book.Count);
        }

        [TestMethod]
        public void FindOneParam()
        {
            PhoneBook book = new PhoneBook();
            book.AddContact(new Contact("Jorko Barborko", "Dupnica", "088123456"));
            book.AddContact(new Contact("Jorko Barborko", "Dupnica", "088123458"));
            book.AddContact(new Contact("Jorko Barborko", "Sofia", "088123456"));

            var matched = book.Find("Jorko Barborko");
            Assert.AreEqual(3, matched.Count);
        }

        [TestMethod]
        public void FindTwoParams()
        {
            PhoneBook book = new PhoneBook();
            book.AddContact(new Contact("Jorko Barborko", "Dupnica", "088123456"));
            book.AddContact(new Contact("Jorko Barborko", "Dupnica", "088123458"));
            book.AddContact(new Contact("Jorko Barborko", "Sofia", "088123456"));

            var matched = book.Find("Jorko Barborko", "Dupnica");
            Assert.AreEqual(2, matched.Count);
        }
    }
}
