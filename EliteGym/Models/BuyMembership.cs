using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteGym.Models
{
    public class BuyMembership
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Purchase date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PurchaseDate { get; set; }

        public int MembershipId { get; set; }

        public virtual Membership Membership { get; set; }

        public int FacilityId { get; set; }

        public virtual Facility Facility { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}