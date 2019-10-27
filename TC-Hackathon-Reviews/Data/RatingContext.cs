using Microsoft.EntityFrameworkCore;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Data
{
    public class RatingContext : DbContext
    {
        public RatingContext(DbContextOptions<RatingContext> options) : base(options)
        {
        }

        public DbSet<RatingItem> RatingItem { get; set; }
    }
}
