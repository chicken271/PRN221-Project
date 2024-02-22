using System;
using System.Collections.Generic;

namespace SWD221_Project.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public string? StudentId { get; set; }
        public string? ClassId { get; set; }
        public DateTime? DateAttended { get; set; }
        public bool? Present { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Student? Student { get; set; }
    }
}
