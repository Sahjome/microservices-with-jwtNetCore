using MicroServices_Jwt_1.Data;
using MicroServices_Jwt_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices_Jwt_1.Services
{
    public class StudentRepository : IStudent
    {

        private StudentsDbContext studentsDb;

        public StudentRepository(StudentsDbContext _studentsDb)
        {
            studentsDb = _studentsDb;
        }

        public void AddStudent(Student student)
        {
            studentsDb.Students.Add(student);
            studentsDb.SaveChanges(true);
        }

        public void DeleteStudent(int id)
        {
            var _student = studentsDb.Students.Find(id);
            studentsDb.Remove(_student);
            studentsDb.SaveChanges(true);
        }

        public Student GetStudent(int id)
        {
            var _student = studentsDb.Students.Find(id);
            return _student;
        }

        public IEnumerable<Student> GetStudents()
        {
            return studentsDb.Students;
        }

        public void UpdateStudent(Student student)
        {
            studentsDb.Students.Update(student);
            studentsDb.SaveChanges(true);
        }
    }
}
