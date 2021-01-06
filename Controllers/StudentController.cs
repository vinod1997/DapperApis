using Microsoft.AspNetCore.Mvc;
using Student.Api.POCO;
using Student.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository; 
        }
        [HttpGet]
        public async Task<ActionResult<Student1>> GellAll()
        {
            var students = await _studentRepository.GetAllStudents();
            return Ok(students);
        }
    }
}
