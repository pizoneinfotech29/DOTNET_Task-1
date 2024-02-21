global using Microsoft.AspNetCore.Mvc;
using task.Data;

namespace task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly DataContext _context;
        public ClassController(DataContext context)
        {
            _context = context;
        } 

       
        [HttpGet]
        public IActionResult GetAllClasses()
        {
            var classes = _context.Classes.Select(c => new ClassDTO
            {
                Name = c.Name,
                NumOfStudents = c.NumOfStudents,
                SchoolId = c.SchoolId,
            }).ToList();
            return Ok(classes);
        }

        //[HttpGet("GetAllClassBySchoolId")]
        //public IActionResult GetAllClassBySchoolId(int SchoolId)
        //{
        //    var Class = _context.Schools.FirstOrDefault(c => c.Classes.Any(s => s.Id == SchoolId));
        //    if (Class == null)
        //    {
        //        return NotFound("SchoolNotFound");
        //    }
        //    return Ok(Class);
        //}

        [HttpGet("GetAllClassBySchoolId")]
        public IActionResult GetAllClassBySchoolId(int schoolId)
        {
            var classes = _context.Classes
                .Where(c => c.SchoolId == schoolId)
                .Select(c => new ClassDTO
                {
                    Name = c.Name,
                    NumOfStudents = c.NumOfStudents,
                    SchoolId = c.SchoolId
                })
                .ToList();

            if (classes == null || classes.Count == 0)
            {
                return NotFound("No classes found for the given school ID.");
            }

            return Ok(classes);
        }



        //[HttpPost]
        //public IActionResult AddClass (ClassModel classM)
        //{
        //    _context.Classes.Add(classM);
        //    _context.SaveChanges();
        //    return Ok(classM);
        //}


        [HttpPost]
        public IActionResult AddClass(ClassDTO classDto)
        {
            try
            {
                if (classDto == null)
                {
                    return BadRequest("Class data is null");
                }

                var school = _context.Schools.Find(classDto.SchoolId);
                if (school == null)
                {
                    return NotFound($"School with ID {classDto.SchoolId} not found");
                }

                var classModel = new ClassModel
                {
                    Name = $"{school.Name} - {classDto.Name}",
                    NumOfStudents = classDto.NumOfStudents,
                    SchoolId = classDto.SchoolId,
                    Schools = school.Name
                };

                _context.Classes.Add(classModel);
                school.NumOfClasses++;
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetAllClasses), new { id = classModel.Id }, classModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return StatusCode(500, "An error occurred while adding the class");
            }
        }




        [HttpPut("{id}")]
        public IActionResult UpdateClass(int id, ClassDTO updatedClassDto)
        {
            var classModel = _context.Classes.Find(id);
            if (classModel == null)
            {
                return NotFound();
            }

            classModel.Name = updatedClassDto.Name;
            classModel.NumOfStudents = updatedClassDto.NumOfStudents;

            _context.SaveChanges();
            return Ok(classModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClass(int id)
        {
            var classModel = _context.Classes.Find(id);
            if (classModel == null)
            {
                return NotFound($"The Class with id {id} not found.");
            }
            _context.Classes.Remove(classModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
