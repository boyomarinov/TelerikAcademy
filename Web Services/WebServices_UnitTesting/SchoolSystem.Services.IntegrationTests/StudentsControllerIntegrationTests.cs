using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem.Models;
using SchoolSystem.Repositories;
using Telerik.JustMock;

namespace SchoolSystem.Services.IntegrationTests
{
    [TestClass]
    public class StudentsControllerIntegrationTests
    {
        [TestMethod]
        public void GetAll_WhenOneStudent_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            models.Add(new Student()
            {
                FirstName = "Petko"
            });

            Mock.Arrange(() => mockRepository.All())
                .Returns(models.AsQueryable);

            var server = new InMemoryHttpServer<Student>("http://localhost:26204/",
                mockRepository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}
