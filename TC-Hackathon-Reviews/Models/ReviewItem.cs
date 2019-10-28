using System.ComponentModel.DataAnnotations;

namespace TC_Hackathon_Reviews.Models
{
    public class ReviewItem
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [MaxLength(250)]
        public string Comment { get; set; }

        [Required]
        public long RatingId { get; set; }
    }
}