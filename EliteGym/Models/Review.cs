using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EliteGym.Models
{
    public class Review
    {
        [ForeignKey("Facility")]
        [Display(Name = "Facility")]
        public int Id { get; set; }

        [Required]
        [Range(0, 10)]
        [Display(Name = "Your interaction with the staff (0 - 10)")]
        public int StaffReview { get; set; }

        [Required]
        [Range(0, 10)]
        [Display(Name = "Cleanliness of the room (0 - 10)")]
        public int CleanlinessScore { get; set; }
        
        [Required]
        [Range(0, 10)]
        [Display(Name = "Overall Experience (0 - 10)")]
        public int OverallExperienceReview { get; set; }

        [Required]
        [Display(Name = "Your Review")]
        [RegularExpression(@"^[a-zA-Z',.\s-!]{4,1600}$", ErrorMessage = "Between 4 and 1600 characters allowed (a-z, A-Z, 0-9!.',)")]
        public string ReviewInfo { get; set; }

        public virtual Facility Facility { get; set; }
    }
}