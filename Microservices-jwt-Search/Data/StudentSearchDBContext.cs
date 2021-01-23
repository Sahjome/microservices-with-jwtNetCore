using Microservices_jwt_Search.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices_jwt_Search.Data
{
    public class StudentSearchDBContext : DbContext
    {
        public StudentSearchDBContext(DbContextOptions<StudentSearchDBContext>options):base(options)
        {
        }

        //register the context for any service or db that we need to searc through here
        public DbSet<Student> Students { get; set; }
    }
}
