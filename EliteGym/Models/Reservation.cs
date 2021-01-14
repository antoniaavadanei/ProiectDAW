using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteGym.Models
{
    public class CustomDateRangeAttribute : RangeAttribute
    {
        public CustomDateRangeAttribute()
          : base(typeof(DateTime),
                DateTime.Now.ToShortDateString(),
                DateTime.Now.AddDays(7).ToShortDateString())
        { }
    }
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        [CustomDateRange]
        [DataType(DataType.Date)]
        [Display(Name = "Starting Date")]
        public DateTime ReservationDate { get; set; }

        public int MembershipId { get; set; }

        public virtual Membership Membership { get; set; }

        public int FacilityId { get; set; }

        public virtual Facility Facility { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
