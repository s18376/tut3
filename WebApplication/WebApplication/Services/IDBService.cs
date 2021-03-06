using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Services
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();

        public string GetStudentById(int id);

        public string AddStudent(Student student);

        public string EditStudentById(int id, string newFn, string newLn, string newIndexNum);

        public string RemoveStudentById(int id);

        public bool IdExists(int id);
    }
}