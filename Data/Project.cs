using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Web.WebPages.Html;

#nullable disable

namespace ProjectManagement.Data2
{

    public partial class Project
    {
        public Project()
        {
            OnProjects = new HashSet<OnProject>();
            ProjectManagers = new HashSet<ProjectManager>();
        }

        public int Id { get; set; }

        [StringLength(11, MinimumLength = 1)]
        [Required]
        public string ProjectName { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime PlannedStartDate { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime PlannedEndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ActualStartDate { get; set; }

        [DataType(DataType.Date), AllowNull]
        public DateTime ActualEndDate { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string ProjectDescription { get; set; }

        public virtual ICollection<OnProject> OnProjects { get; set; }
        public virtual ICollection<ProjectManager> ProjectManagers { get; set; }

        public int PlannedProjectTime(DateTime plannedStartDate, DateTime plannedEndDate)
        {
            int plannedTime = (int)plannedEndDate.Subtract(plannedStartDate).TotalDays;

            return plannedTime;
        }
        
    }
}
