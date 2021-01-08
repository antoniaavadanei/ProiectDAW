using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteGym.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

    }
}