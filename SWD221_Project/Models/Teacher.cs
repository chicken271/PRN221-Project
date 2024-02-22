using System;
using System.Collections.Generic;

namespace SWD221_Project.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        public string TeacherId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
