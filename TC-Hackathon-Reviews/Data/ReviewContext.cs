using Microsoft.EntityFrameworkCore;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Data
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options)
        {
        }

        public DbSet<ReviewItem> ReviewItem { get; set; }
        public DbSet<RatingItem> RatingItem { get; set; }
    }
}