using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Practice.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Credit { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CourseStudentEnroll> CourseStudentEnrolls { get; set; }
        public virtual ICollection<TeacherCourseEnrollment> TeacherCourseEnrollment { get; set; }
        public virtual ICollection<CourseRoomAssign> CourseRoomAssigns { get; set; }
    }
}