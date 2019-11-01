using System.ComponentModel.DataAnnotations;

namespace TC_Hackathon_Reviews.Models
{
    public class RatingItem
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required] 
        public string Name { get; set; }
    }
}