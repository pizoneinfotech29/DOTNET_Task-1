namespace task.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<SchoolModel> Schools { get; set; }
        public DbSet<ClassModel> Classes { get; set; }
        public DbSet<StudentsModel> Students { get; set; }
        //public object Students { get; internal set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<SchoolModel>().HasData(
        //        new SchoolModel { 
        //            Id = 1, 
        //            Name = "LKS", 
        //            NumOfClasses = 10,
        //            ClassId = 1},
        //        new SchoolModel { 
        //            Id = 2, 
        //            Name = "VIS", 
        //            NumOfClasses = 12,
        //            ClassId = 2
        //        },
        //        new SchoolModel { 
        //            Id = 3, 
        //            Name = "KVM", 
        //            NumOfClasses = 9,
        //            ClassId = 3
        //        });

        //    modelBuilder.Entity<ClassModel>().HasData(
        //       new ClassModel { 
        //           Id = 1,
        //           Name = "C-A", 
        //           NumOfStudents = 25, 
        //           Schools= "LKS",
        //           SchoolId = 1},
        //       new ClassModel { 
        //           Id = 2, 
        //           Name = "C-B", 
        //           NumOfStudents = 10, 
        //           Schools = "VIS",
        //           SchoolId = 2},
        //       new ClassModel { 
        //           Id = 3, 
        //           Name = "C-C", 
        //           NumOfStudents = 49, 
        //           Schools = "KVM",
        //           SchoolId = 3}
        //       );

        //    modelBuilder.Entity<StudentsModel>().HasData(
        //        new StudentsModel { 
        //            Id = 1, 
        //            Name = "LKS", 
        //            Class = 3, 
        //            Age = 12, 
        //            ROllNo = 20},
        //        new StudentsModel { 
        //            Id = 2, 
        //            Name = "VIS", 
        //            Class = 4, 
        //            Age = 14, 
        //            ROllNo = 24 },
        //        new StudentsModel { 
        //            Id = 3, 
        //            Name = "KVM", 
        //            Class = 5, 
        //            Age = 16, 
        //            ROllNo = 28 });

        //}
    }
}
