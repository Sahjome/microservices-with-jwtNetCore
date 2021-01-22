using MicroServices_Jwt_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices_Jwt_1.Data
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions<StudentsDbContext>options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
