using System;
using System.Collections.Generic;

namespace SWD221_Project.Models
{
    public partial class Class
    {
        public Class()
        {
            Attendances = new HashSet<Attendance>();
            Works = new HashSet<Work>();
        }

        public string ClassId { get; set; } = null!;
        public string? TeacherId { get; set; }
        public string? ClassName { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
