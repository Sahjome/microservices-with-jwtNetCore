using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices_jwt_Search.Models
{
    public class Student
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Maximum characters is 25")]
        public string Name { get; set; }
        public int Age { get; set; }
        [RegularExpression(@"[1-6]", ErrorMessage = "choose between 1 - 6")]
        public int Level { get; set; }
        [RegularExpression(@"[A-E]", ErrorMessage = "choose between A,B,C,D,E")]
        public string LevelArm { get; set; }
    }
}
