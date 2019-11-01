using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class Review
    {
        public long Id { get; set; }

        [MaxLength(250)]
        public string Comment { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public int RatingId { get; set; }
    }

    public class ReviewViewModel : Review
    {
        [Display(Name = "Rating")] 
        public string RatingName;

        [Display(Name = "Rating")]
        public IEnumerable<SelectListItem> RatingDropdown { get; set; }
    }
}