using System.ComponentModel.DataAnnotations;

namespace task.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        
        public int NumOfStudents { get; set; }

        public int SchoolId { get; set; }
        public string? Schools { get; set; }
        public SchoolModel? School { get; set; }
        public List<StudentsModel>? Students { get; set; }
    }
}
