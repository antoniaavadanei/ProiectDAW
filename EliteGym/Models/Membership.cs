﻿using System;
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
        public string MembershipDuration { get; set; }

        [Required]
        [Display(Name = "Price(RON)")]
        public int MembershipPrice { get; set; }

        public virtual ICollection<BuyMembership> BuyMemberships { get; set; }

    }
}