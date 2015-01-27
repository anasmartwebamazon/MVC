using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Practice.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public double CreditToBeTaken { get; set; }
        public double RemainingCredit { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<TeacherCourseEnrollment> TeacherCourseEnrollment { get; set; }
    }
}