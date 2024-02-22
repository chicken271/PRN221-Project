using System;
using System.Collections.Generic;

namespace SWD221_Project.Models
{
    public partial class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            StudentWorkProgresses = new HashSet<StudentWorkProgress>();
        }

        public string StudentId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<StudentWorkProgress> StudentWorkProgresses { get; set; }
    }
}
