using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Uni_Practice.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(): base("UniversityPracticeJanuary")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder); //
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TeacherCourseEnrollment> TeacherCourseEnrollments { get; set; }
        public DbSet<CourseStudentEnroll> CourseStudentEnrolls { get; set; }
        public DbSet<CourseRoomAssign> CourseRoomAssigns { get; set; }
 
    }
}