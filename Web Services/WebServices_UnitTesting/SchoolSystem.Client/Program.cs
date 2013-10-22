using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using SchoolSystem.Data;
using SchoolSystem.Models;

namespace SchoolSystem.Client
{
    public static class Program
    {
        public static void Main()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:26204/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //School testSchool = new School()
            //{
            //    Name = "Telerik Academy",
            //    Location = "Mladost 1"
            //};

            //SchoolSystemDAL.AddSchool(client, testSchool);

            foreach (var school in SchoolSystemDAL.GetSchools(client))
            {
                Console.WriteLine(school.SchoolId + " " + school.Name + " " + school.Location);
            }
        }
    }
}
