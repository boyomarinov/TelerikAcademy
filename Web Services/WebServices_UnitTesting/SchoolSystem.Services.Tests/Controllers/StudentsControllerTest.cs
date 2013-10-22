using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem.Models;
using SchoolSystem.Repositories;
using SchoolSystem.Services.Controllers;
using SchoolSystem.Services.Models;
using SchoolSystem.Services.Tests.Fake;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace SchoolSystem.Services.Tests.Controllers
{
    /// <summary>
    /// Summary description for StudentsControllerTest
    /// </summary>
    [TestClass]
    public class StudentsControllerTest
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/students");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "students");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddSimpleStudentTest()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var studentModel = new StudentModel()
            {
                FirstName = "Petko"
            };

            var studentEntity = new Student()
            {
                StudentId = 1,
                FirstName = studentModel.FirstName
            };

            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true);
                //.Returns(studentEntity);

            var controller = new StudentsController(repository);
            SetupController(controller);
            controller.PostStudent(studentModel);

            Assert.IsTrue(isItemAdded);
        }

        [TestMethod]
        public void GetAllStudentsTest()
        {
            var repository = Mock.Create<IRepository<Student>>();            
            var studentToAdd = new Student()
            {
                FirstName = "Petko"
            };
            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentToAdd);
            Mock.Arrange(() => repository.All()).Returns(studentEntities.AsQueryable);

            var controller = new StudentsController(repository);

            var studentModels = controller.Get();
            Assert.IsTrue(studentModels.Count() == 1);
            Assert.AreEqual(studentToAdd.FirstName, studentModels.First().FirstName);
        }

        [TestMethod]
        public void GetAllStudents_ReturnOnlyOneTest()
        {
            var repository = new FakeRepository<Student>();

            var studentToAdd = new Student()
            {
                FirstName = "Test student"
            };
            repository.entities.Add(studentToAdd);

            var controller = new StudentsController(repository);

            var studentsModels = controller.Get();
            Assert.IsTrue(studentsModels.Count() == 1);
            Assert.AreEqual(studentToAdd.FirstName, studentsModels.First().FirstName);
        }

        [TestMethod]
        public void TestGetByIdStudent()
        {
            var repository = Mock.Create<IRepository<Student>>();
            var student = new Student()
            {
                StudentId = 1,
                FirstName = "Pesho",
                LastName = "Peshov",
                Grade = 3
            };

            Mock.Arrange<Student>(
                () => repository.Get(student.StudentId))
                .IgnoreArguments()
                .Returns(student)
                .MustBeCalled();

            var controller = new StudentsController(repository);
            SetupController(controller);
            var result = controller.Get(student.StudentId);

            Assert.AreEqual(result.StudentId, student.StudentId);
            Assert.AreEqual(result.FirstName, student.FirstName);
            Assert.AreEqual(result.LastName, student.LastName);
            Assert.AreEqual(result.Grade, student.Grade);
        }

        [TestMethod]
        public void UpdateStudentTest()
        {
            bool isItemUpdated = false;
            var repository = Mock.Create<IRepository<Student>>();

            var studentModel = new StudentModel()
            {
                FirstName = "Petko"
            };
            var studentEntity = new Student()
            {
                StudentId = 1,
                FirstName = studentModel.FirstName
            };
          
            var controller = new StudentsController(repository);
            SetupController(controller);
            controller.PostStudent(studentModel);

            Mock.Arrange(() => repository.Update(Arg.IsAny<int>(), Arg.IsAny<Student>()))
              .DoInstead(() => isItemUpdated = true)
              .Returns(studentEntity);

            var newStudent = new Student()
            {
                StudentId = 1,
                FirstName = "New first name"
            };

            controller.Put(1, newStudent);

            Assert.IsTrue(isItemUpdated);
        }
    }
}
    