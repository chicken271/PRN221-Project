﻿using System;
using System.Collections.Generic;

namespace SWD221_Project.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
