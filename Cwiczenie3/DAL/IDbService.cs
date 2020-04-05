using Cwiczenie3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenie3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();

        public Student GetStudent(int id);
        public void Put(int id, Student student);
        public void AddStudent(Student student);
        public void Delete(int id);

    }
}
