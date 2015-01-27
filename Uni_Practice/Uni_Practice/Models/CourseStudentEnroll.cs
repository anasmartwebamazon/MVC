using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Uni_Practice.Models
{
    public class CourseStudentEnroll
    {
        public int CourseStudentEnrollId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EnrollDate { get; set; }
        public string Session { get; set; }
        public double? ObtainedNumber { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}