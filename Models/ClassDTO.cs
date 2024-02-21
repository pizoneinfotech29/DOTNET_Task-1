using System.ComponentModel.DataAnnotations;

namespace task.Models
{
    public class ClassDTO
    {
        public string? Name { get; set; }

        [Range(0, 50, ErrorMessage = "Please enter no of students between (0-50)")]
        public int NumOfStudents { get; set; }
        public int SchoolId { get; set; }
    }
}
