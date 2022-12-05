using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

#nullable disable

namespace ProjectManagement.Data2
{
    public partial class ProjectManager 
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
