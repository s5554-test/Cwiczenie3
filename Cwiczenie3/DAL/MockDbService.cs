using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenie3.Controllers;
using Cwiczenie3.Models;

namespace Cwiczenie3.DAL
{
    public class MockDbService : IDbService
    {
        private static List<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student { Id = 1, Lastname = "Potocki" },
                new Student { Id = 2, Lastname = "Abacki" },
                new Student { Id = 3, Lastname = "Kmicic" }
            };
            
        }
        public void Delete(int id)
        {
            Student deletedStudent = GetStudent(id);
            _students.Remove(deletedStudent);
        }

        public Student GetStudent(int id)
        {
            Student studentsId = _students.Find(g => g.Id == id);
            return studentsId;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public void Put(int id, Student student)
        {
            Student foundStudent = GetStudent(id);
            foundStudent.Lastname = student.Lastname;
        }
    }
}
