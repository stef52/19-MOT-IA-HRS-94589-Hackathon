using System.ComponentModel.DataAnnotations;

namespace TC_Hackathon_Reviews.Models
{
    public class ReviewItem
    {
        public long Id { get; set; }

        [MaxLength(250)]
        public string Comment { get; set; }

        //[Required]
        //public RatingItem RatingId { get; set; }

        [Required]
        public RatingItem Rating { get; set; }
    }
}