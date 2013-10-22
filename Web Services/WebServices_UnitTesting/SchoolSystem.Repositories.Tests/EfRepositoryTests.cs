using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem.Data;
using SchoolSystem.Models;

namespace SchoolSystem.Repositories.Tests
{
    [TestClass]
    public class EfRepositoryTests
    {
        public SchoolSystemContext dbContext { get; set; }

        static Random rand = new Random();

        public IRepository<School> categoriesRepository { get; set; }

        private static TransactionScope tranScope;

        public EfRepositoryTests()
        {
            this.dbContext = new SchoolSystemContext();
            this.categoriesRepository = new EfRepository<School>(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestCloseTransaction()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void TestSimpleAddViaContext()
        {
            var school = new School()
            {
                Name = "Telerik",
                Location = "Mladost"
            };
            dbContext.Set<School>().Add(school);
            dbContext.SaveChanges();

            Assert.IsTrue(school.SchoolId > 0);
        }

        [TestMethod]
        public void TestSimpleAddViaRepository()
        {
            var school = new School()
            {
                Name = "Telerik",
                Location = "Mladost"
            };
            categoriesRepository.Add(school);

            Assert.IsTrue(school.SchoolId > 0);
        }

        [TestMethod]
        public void TestAddedSchoolDataIntegrity()
        {
            var school = new School()
            {
                Name = "Telerik",
                Location = "Mladost"
            };
            var createdSchool = categoriesRepository.Add(school);

            var foundSchool = this.dbContext.Set<School>().Find(createdSchool.SchoolId);
            Assert.IsNotNull(foundSchool);
            Assert.AreEqual(createdSchool.Name, foundSchool.Name);
            Assert.AreEqual(createdSchool.Location, foundSchool.Location);
        }
    }
}
