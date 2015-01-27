using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Practice.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CourseStudentEnroll> CourseStudentEnrolls { get; set; }
    }
}