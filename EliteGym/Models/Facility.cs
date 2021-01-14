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
        [RegularExpression(@"^[a-zA-Z]{3,30}$", ErrorMessage = "Between 3 and 30 characters allowed (a-z, A-Z)")]
        public string FacilityName { get; set; }


        [Required]
        [Display(Name = "Scheduled Day")]
        [RegularExpression(@"^[a-zA-Z]{3,30}$", ErrorMessage = "Between 3 and 30 characters allowed (a-z, A-Z)")]
        public string ScheduleDay { get; set; }

        [Required]
        [Display(Name = "Scheduled Hour")]
        [RegularExpression(@"^[0-9'\s-]{3,30}$", ErrorMessage = "Between 3 and 30 characters allowed (0-9)")]
        public string ScheduleHour { get; set; }

        public virtual Review Review { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}