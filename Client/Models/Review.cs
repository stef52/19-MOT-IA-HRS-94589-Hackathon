using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class Review
    {
        public long Id { get; set; }

        [MaxLength(250)] 
        public string Comment { get; set; }

        [Required] 
        public int Rating { get; set; }
    }
}