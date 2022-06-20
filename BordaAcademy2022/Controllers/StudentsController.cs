using BordaAcademy2022.Dtos;
using BordaAcademy2022.Entities;
using BordaAcademy2022.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BordaAcademy2022.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // CRUD, Create, Read, Update, Delete

        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentRepository.GetStudents();

            return Ok(students);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            _studentRepository.CreateStudent(student);

            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            Student? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                throw new KeyNotFoundException();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            if(studentDto.Name is null)
            {
                throw new ArgumentException();
            }

            Student? student = _studentRepository.GetStudentById(id);
            
            if (student == null)
            {
                throw new KeyNotFoundException();
            }

            student.Name = studentDto.Name;
            student.Surname = studentDto.Surname;

            _studentRepository.UpdateStudent(student);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentRepository.DeleteStudent(id);

            return NoContent();
        }
    }
}
