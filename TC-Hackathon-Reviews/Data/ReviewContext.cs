using Microsoft.EntityFrameworkCore;

namespace TC_Hackathon_Reviews.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options)
        {
        }

        public DbSet<ReviewItem> ReviewItem { get; set; }
    }
}