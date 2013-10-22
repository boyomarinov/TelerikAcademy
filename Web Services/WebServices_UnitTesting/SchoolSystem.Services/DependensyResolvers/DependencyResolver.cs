using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Repositories;
using SchoolSystem.Services.Controllers;

namespace SchoolSystem.Services.DependensyResolvers
{
    public class DependencyResolver : IDependencyResolver
    {
        private static SchoolSystemContext context = new SchoolSystemContext();
        private static EfRepository<School> schoolRepository = new EfRepository<School>(context);
        private static EfRepository<Student> studentRepository = new EfRepository<Student>(context);
        private static EfRepository<Mark> markRepository = new EfRepository<Mark>(context);

        public object GetService(Type serviceType)
        {   
            //TODO: Add DbContext class to Repositories!
            if (serviceType == typeof(IRepository<School>))
            {
                return new SchoolsController(schoolRepository);
            }
            else if (serviceType == typeof(IRepository<Student>))
            {
                return new StudentsController(studentRepository);
            }
            else if (serviceType == typeof(IRepository<Mark>))
            {
                return new MarksController(markRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }
    }
}