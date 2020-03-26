using System.Collections.Generic;
using WebApplication.Models;
using System.Linq;

namespace WebApplication.Services
{
    public class DbService : IDbService
    {
        private static readonly IEnumerable<Student> Students;

        static DbService()
        {
            Students = new List<Student>
            {
                new Student {IdStudent = 1, FirstName = "Piotr", LastName = "Baler", IndexNumber = "s1531"},
                new Student {IdStudent = 2, FirstName = "Mark", LastName = "Schultz", IndexNumber = "s2686"},
                new Student {IdStudent = 3, FirstName = "Bill", LastName = "Poppins", IndexNumber = "s8764"}
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return Students;
        }

        public string GetStudentById(int id)
        {
            foreach (var student in Students)
                if (student.IdStudent == id)
                    return student.ToString();

            return "student not found";
        }

        public bool IdExists(int id)
        {
            return Students.Any(student => student.IdStudent == id);
        }

        public string AddStudent(Student student)
        {
            ((List<Student>) Students).Add(student);
            return "Student successfully added";
        }

        public string EditStudentById(int id, string newFn, string newLn, string newIndexNumber)
        {
            foreach (var student in Students)
            {
                if (student.IdStudent != id) continue;
                if (newFn != null) student.FirstName = newFn;
                if (newLn != null) student.LastName = newLn;
                if (newIndexNumber != null) student.IndexNumber = newIndexNumber;
                return "Student successfully updated";
            }

            return "Student failed to update";
        }

        public string RemoveStudentById(int id)
        {
            var studentToRm = ((List<Student>) Students).SingleOrDefault(student => student.IdStudent == id);
            if (studentToRm == null) return "Student failed to remove";
            ((List<Student>) Students).Remove(studentToRm);
            return "Student successfully removed";
        }
    }
}