using ProjectManagement.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectManagement.Data2
{
    public partial class Employee
    {
        public Employee()
        {
            ProjectManagers = new HashSet<ProjectManager>();
        }

        public Employee(string name, string surname, string email)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
        }

        public int Id { get; set; }

        [StringLength(128, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(128, MinimumLength = 3)]
        [Required]
        public string Surname { get; set; }

      //  [RegularExpression(@"/^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/")]
        [Required]
        public string Email { get; set; }
        
        public virtual ICollection<ProjectManager> ProjectManagers { get; set; }
    }
}
