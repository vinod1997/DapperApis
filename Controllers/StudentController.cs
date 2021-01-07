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

        [HttpPost]
        public async Task<ActionResult> AddStudent(Student1 entity)
        {
            await _studentRepository.AddStudent(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(Product entity, int id)
        {
            await _studentRepository.GetById(entity, id);
            return Ok(entity);
        }
    }
}
