using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectManagement.Data2
{
    public partial class OnProject : Project
    {
        public int ID { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int ClientPartnerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        public bool IsClient { get; set; }
        public bool IsPartner { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }

        public virtual ClientPartner ClientPartner { get; set; }
        public virtual Project Project { get; set; }

        public int PartnershipTime(DateTime dateStart)
        {

            int partnershipTime = (int) DateTime.Now.Subtract(dateStart).TotalDays;

            return partnershipTime;
        }

        public override string ToString()
        {
            if (IsClient)
            {
                return $"Partnerystes su clientu laikas: {PartnershipTime(DateStart)} dienos.";
            }
            return $"Bendradarbiavimo su partneriu laikas: {PartnershipTime(DateStart)} dienos.";
        }
    }
}
