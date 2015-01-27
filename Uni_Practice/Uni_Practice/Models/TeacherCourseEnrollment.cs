using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Practice.Models
{
    public class TeacherCourseEnrollment
    {
        public int TeacherCourseEnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public DateTime EnrollDate { get; set; }
        public string Session { get; set; }
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}