using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices_Jwt_1.Models;
using MicroServices_Jwt_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices_Jwt_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudent studentrepository;

        public StudentsController(IStudent _studentrepository)
        {
            studentrepository = _studentrepository;
        }

        // GET: api/Students
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var _students = studentrepository.GetStudents();
                return StatusCode(StatusCodes.Status200OK, _students);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var _student = studentrepository.GetStudent(id);
                return (_student == null) ? StatusCode(StatusCodes.Status404NotFound, "No record found.") :
                    StatusCode(StatusCodes.Status200OK, _student);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // POST: api/Students
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentrepository.AddStudent(student);
                    return StatusCode(StatusCodes.Status201Created, "Record Created successfully.");
                }
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            try
            {

                if (id != student.Id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                studentrepository.UpdateStudent(student);
                return StatusCode(StatusCodes.Status200OK, "Record Updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                studentrepository.DeleteStudent(id);
                return StatusCode(StatusCodes.Status200OK, "Record Deleted successfully.");
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,  ex.Message);

            }
        }
    }
}
