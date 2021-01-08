using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteGym.Models
{
    public class Facility
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Facility")]
        public string FacilityName { get; set; }


        [Required]
        [Display(Name = "Scheduled Day")]
        public string ScheduleDay { get; set; }

        [Required]
        [Display(Name = "Scheduled Hour")]
        public string ScheduleHour { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}