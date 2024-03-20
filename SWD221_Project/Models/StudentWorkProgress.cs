using System;
using System.Collections.Generic;

namespace SWD221_Project.Models
{
    public partial class StudentWorkProgress
    {
        public int ProgressId { get; set; }
        public string StudentId { get; set; }
        public int? WorkId { get; set; }
        public bool? Complete { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Work? Work { get; set; }
    }
}
