using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using task.Data;
using task.Models;

namespace task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DataContext _context;
        public StudentsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.Students.Select(s => new StudentsDTO
            {
                Name = s.Name,
                Class = s.Class,
                Age = s.Age,
                ROllNo = s.ROllNo
            }).ToList();
            return Ok(students);
        }

        [HttpGet("GetAllStudentByClasslId")]
        public IActionResult GetAllStudentByClasslId(int classId)
        {
            var students = _context.Students
                .Where(s => s.Class == classId)
                .Select(s => new StudentsDTO
                {
                    Name = s.Name,
                    Class = s.Class,
                    Age = s.Age,
                    ROllNo = s.ROllNo
                })
                .ToList();

            if (students == null || students.Count == 0)
            {
                return NotFound("No students found for the given class ID.");
            }

            return Ok(students);
        }

        [HttpPost]
        public IActionResult AddStudent(StudentsDTO studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Student data is null");
            }

            var classModel = _context.Classes.Find(studentDto.Class);
            if (classModel == null)
            {
                return NotFound($"Class with ID {studentDto.Class} not found");
            }

            if (IsClassFull(classModel))
            {
                return BadRequest("The class has reached the maximum number of students.");
            }

            var studentModel = new StudentsModel
            {
                Name = studentDto.Name,
                Class = studentDto.Class,
                Age = studentDto.Age,
                ROllNo = studentDto.ROllNo
            };

            _context.Students.Add(studentModel);
            classModel.NumOfStudents++;
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllStudents), new { id = studentModel.Id }, studentModel);
        }

        private bool IsClassFull(ClassModel classModel)
        {
            return classModel.NumOfStudents >= 50;
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, StudentsDTO updatedStudentDto)
        {
            var studentModel = _context.Students.Find(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            studentModel.Name = updatedStudentDto.Name;
            studentModel.Class = updatedStudentDto.Class;
            studentModel.Age = updatedStudentDto.Age;
            studentModel.ROllNo = updatedStudentDto.ROllNo;

            _context.SaveChanges();
            return Ok(studentModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var studentModel = _context.Students.Find(id);
            if (studentModel == null)
            {
                return NotFound($"The student with id {id} not found.");
            }
            _context.Students.Remove(studentModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
