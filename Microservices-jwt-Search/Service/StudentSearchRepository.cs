using Microservices_jwt_Search.Data;
using Microservices_jwt_Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices_jwt_Search.Service
{
    public class StudentSearchRepository : ISearch<Student>
    {
        //we need to get the dbcontext which is our connector/communicator
        //with the db for the respective table whose context we need

        private StudentSearchDBContext searchDB;

        public StudentSearchRepository(StudentSearchDBContext _searchDB)
        {
            searchDB = _searchDB;
        }

        IQueryable ISearch<Student>.GetEntity(string entityName)
        {
            var student = searchDB.Students.Where(p => p.Name.StartsWith(entityName));
            return student;
        }
    }
}
