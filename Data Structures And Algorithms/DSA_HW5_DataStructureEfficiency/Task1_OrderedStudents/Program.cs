using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task1_OrderedStudents
{
    class Program
    {
        private static OrderedMultiDictionary<string, Student> studentsByCourse = new OrderedMultiDictionary<string, Student>(true);

        public static string GetStudentsByKey(string key)
        {
            var matchedStudents = studentsByCourse[key];
            if (matchedStudents.Count == 0)
            {
                return "There are no students enrolled in this class.";
            }

            return string.Join(", ", matchedStudents);
        }
        
        public static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"../../students.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var splitted = line.Split('|');
                    Student created = new Student(splitted[0].Trim(), splitted[1].Trim());
                    studentsByCourse.Add(splitted[2].Trim(), created);

                    line = reader.ReadLine();
                }

                Console.WriteLine(string.Join(Environment.NewLine,
                    studentsByCourse.Keys.Select(x => String.Format("{0}: {1}", x, GetStudentsByKey(x))
                    )
                ));
            }
        }
    }
}
