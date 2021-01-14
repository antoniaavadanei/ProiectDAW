using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteGym.Models
{
    public class Membership
    {
        public int Id { get; set; }
   
        [Required]
        [Display(Name = "Duration")]
        [RegularExpression(@"^[a-zA-Z0-9]{3,30}$", ErrorMessage = "Between 3 and 30 characters allowed (a-z, A-Z,0-9)")]
        public string MembershipDuration { get; set; }

        [Required]
        [Range(0,1000)]
        [Display(Name = "Price(RON)")]
        public int MembershipPrice { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}