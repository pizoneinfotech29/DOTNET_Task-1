using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using task.Data;
using task.Models;

namespace task.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly DataContext _context;
        public SchoolController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllSchools()
        {
            var schools = _context.Schools.Select(s => new SchoolDTO
            {
                Name = s.Name,
                NumOfClasses = s.NumOfClasses,
                ClassId = s.ClassId,
            }).ToList();
            return Ok(schools);
        }

        //[HttpGet("GetAllClassesBySchoolId")]
        //public IActionResult GetAllClassesBySchoolId(int schoolId)
        //{
        //    var school = _context.Schools
        //        .Include(s => s.Classes)
        //        .FirstOrDefault(s => s.Id == schoolId);

        //    if (school == null)
        //    {
        //        return NotFound("School Not Found");
        //    }

        //    var classesDto = school.Classes.Select(c => new ClassDTO
        //    {
        //        Id = c.Id,
        //        Name = c.Name,
        //        NumOfStudents = c.NumOfStudents,
        //        SchoolId = c.SchoolId
        //    }).ToList();

        //    return Ok(classesDto);
        //}


        [HttpPost]
        public IActionResult AddSchool(SchoolDTO schoolDto)
        {
            if (schoolDto == null)
            {
                return BadRequest("School data is null");
            }

            var schoolModel = new SchoolModel
            {
                Name = schoolDto.Name,
                NumOfClasses = schoolDto.NumOfClasses
            };

            _context.Schools.Add(schoolModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllSchools), new { id = schoolModel.Id }, schoolModel);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateSchool(int id, SchoolDTO updatedSchoolDto)
        {
            var schoolModel = _context.Schools.Find(id);
            if (schoolModel == null)
            {
                return NotFound();
            }

            schoolModel.Name = updatedSchoolDto.Name;
            schoolModel.NumOfClasses = updatedSchoolDto.NumOfClasses;

            _context.SaveChanges();
            return Ok(schoolModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchool(int id)
        {
            var schoolModel = _context.Schools.Find(id);
            if (schoolModel == null)
            {
                return NotFound($"The School with id {id} not found.");
            }
            _context.Schools.Remove(schoolModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
