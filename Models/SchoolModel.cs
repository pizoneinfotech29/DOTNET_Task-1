namespace task.Models
{
    public class SchoolModel
    {
        //internal object School;

        public int Id { get; set; }
        public string?  Name { get; set; }
        public int NumOfClasses { get; set; } 
        //public int Class { get; set; }
        public int ClassId { get; set; }
        public List <ClassModel>? Classes { get; set; }
        
    }
}
