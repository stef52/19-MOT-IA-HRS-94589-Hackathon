using System.ComponentModel.DataAnnotations;

namespace TC_Hackathon_Reviews.Models
{
    public class ReviewItem
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        [Required]
        public bool Rating { get; set; }
    }
}
