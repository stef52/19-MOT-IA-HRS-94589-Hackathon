using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Client.Models
{
    public class Review
    {
        public long Id { get; set; }

        [MaxLength(250)] 
        public string Comment { get; set; }

        [Required] 
        public int RatingId { get; set; }
    }

    public class ReviewViewModel : Review
    {
        public IEnumerable<SelectListItem> RatingDropdown { get; set; }

        public string RatingName;

    }
}