using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Practice.Models
{
    public class CourseRoomAssign
    {
        public int CourseRoomAssignId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Course Course { get; set; }
        public virtual Room Room { get; set; }

    }
}