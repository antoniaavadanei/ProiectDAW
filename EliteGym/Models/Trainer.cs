using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteGym.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Trainer Name")]
        public string Name { get; set; }

        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
    }
}