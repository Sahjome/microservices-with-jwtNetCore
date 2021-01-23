using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices_jwt_Search.Models;
using Microservices_jwt_Search.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservices_jwt_Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSearchController : ControllerBase
    {
        //connect the controller to the repository via the
        //interface. No controller should talk directly to the 
        //repository b/c of ...

        private readonly ISearch<Student> studentDb;

        //for anymore dbcontext, add more controllers
        public StudentSearchController(ISearch<Student> _search)
        {
            studentDb = _search;
        }

        [HttpGet]
        public IActionResult Get(string param)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(param))
            {
                return BadRequest(ModelState);
            }
            var _student = studentDb.GetEntity(param);
            return Ok(_student);
        }
    }
}