using System;
using System.Collections.Generic;

namespace SWD221_Project.Models
{
    public partial class BelongTo
    {
        public string? StudentId { get; set; }
        public string? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Student? Student { get; set; }
    }
}
