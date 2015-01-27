using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Practice.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CourseRoomAssign> CourseRoomAssigns { get; set; }
    }
}