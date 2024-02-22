using System;
using System.Collections.Generic;

namespace SWD221_Project.Models
{
    public partial class Work
    {
        public Work()
        {
            StudentWorkProgresses = new HashSet<StudentWorkProgress>();
        }

        public int WorkId { get; set; }
        public string? ClassId { get; set; }
        public string? WorkName { get; set; }
        public string? Description { get; set; }

        public virtual Class? Class { get; set; }
        public virtual ICollection<StudentWorkProgress> StudentWorkProgresses { get; set; }
    }
}
