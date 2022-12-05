using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectManagement.Data2
{
    public partial class ClientPartner
    {
        public ClientPartner()
        {
            OnProjects = new HashSet<OnProject>();
        }
        public ClientPartner(string cpName, string cpAddress, string cpDetails, ICollection<OnProject> onProjects)
        {
            CpName = cpName;
            CpAddress = cpAddress;
            CpDetails = cpDetails;
            OnProjects = onProjects;
        }

        public int Id { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string CpName { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string CpAddress { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string CpDetails { get; set; }

        public virtual ICollection<OnProject> OnProjects { get; set; }
    }
}
