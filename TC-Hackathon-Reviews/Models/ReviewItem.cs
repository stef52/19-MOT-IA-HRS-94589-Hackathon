using System.ComponentModel.DataAnnotations;

namespace TC_Hackathon_Reviews.Models
{
    public class ReviewItem
    {
        public long Id { get; set; }

        [MaxLength(250)]
        public string Comment { get; set; }

        [Required]
        public long RatingId { get; set; }

        public RatingItem Rating { get; set; }
    }
}