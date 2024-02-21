namespace task.Models
{
    public class StudentsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }   
        public int Class { get; set; }
        public int Age { get; set; }
        public int ROllNo { get; set; }
        public List<ClassModel>? Classes { get; set; }
        
    }
}
