using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using SchoolSystem.Models;


namespace SchoolSystem.Data
{
    public static class SchoolSystemDAL
    {
        #region Students
        public static IEnumerable<Student> GetStudents(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Students").Result;

            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                return students;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static Student GetStudent(HttpClient client, int id)
        {
            HttpResponseMessage response = client.GetAsync("api/Students/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                return students.First();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static void AddStudent(HttpClient client, Student student)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PostAsJsonAsync("api/Students", student).Result;
            }
            else
            {
                response = client.PostAsJsonAsync("api/Students", student).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Student {0} added successfully", student.FirstName + " " + student.LastName);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void UpdateStudent(HttpClient client, int id, Student student)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PutAsJsonAsync("api/Students/" + id, student).Result;
            }
            else
            {
                response = client.PutAsXmlAsync("api/Students/" + id, student).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Student {0} updated successfully", student.FirstName + " " + student.LastName);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void DeleteStudent(HttpClient client, int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/Students/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Student {0} deleted successfully", id);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        #endregion

        #region Schools
        public static IEnumerable<School> GetSchools(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Schools").Result;

            if (response.IsSuccessStatusCode)
            {
                var schools = response.Content.ReadAsAsync<IEnumerable<School>>().Result;
                return schools;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static School GetSchool(HttpClient client, int id)
        {
            HttpResponseMessage response = client.GetAsync("api/Schools/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var schools = response.Content.ReadAsAsync<IEnumerable<School>>().Result;
                return schools.First();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static void AddSchool(HttpClient client, School school)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PostAsJsonAsync("api/Schools", school).Result;
            }
            else
            {
                response = client.PostAsJsonAsync("api/Schools", school).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("School {0} added successfully", school.Name);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void UpdateSchool(HttpClient client, int id, School school)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PutAsJsonAsync("api/Schools/" + id, school).Result;
            }
            else
            {
                response = client.PutAsXmlAsync("api/Schools/" + id, school).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("School {0} updated successfully", school.Name);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void DeleteSchool(HttpClient client, int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/Schools/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("School {0} deleted successfully", id);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        #endregion

        #region Marks
        public static IEnumerable<Mark> GetMarks(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Marks").Result;

            if (response.IsSuccessStatusCode)
            {
                var marks = response.Content.ReadAsAsync<IEnumerable<Mark>>().Result;
                return marks;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static Mark GetMark(HttpClient client, int id)
        {
            HttpResponseMessage response = client.GetAsync("api/Marks/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var marks = response.Content.ReadAsAsync<IEnumerable<Mark>>().Result;
                return marks.First();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static void AddMark(HttpClient client, Mark mark)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PostAsJsonAsync("api/Marks", mark).Result;
            }
            else
            {
                response = client.PostAsJsonAsync("api/Marks", mark).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Mark {0} added successfully", mark.Value);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void UpdateMark(HttpClient client, int id, Mark mark)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PutAsJsonAsync("api/Marks/" + id, mark).Result;
            }
            else
            {
                response = client.PutAsXmlAsync("api/Marks/" + id, mark).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Mark {0} updated successfully", mark.Value);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void DeleteMark(HttpClient client, int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/Marks/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Mark {0} deleted successfully", id);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        #endregion
    }
}
