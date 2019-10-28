using System.Collections.Generic;

namespace TC_Hackathon_Reviews.Models
{
    public class RatingItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ReviewItem> Reviews { get; set; }
    }
}