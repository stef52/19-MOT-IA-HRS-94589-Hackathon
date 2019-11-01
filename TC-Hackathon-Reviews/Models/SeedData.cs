using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TC_Hackathon_Reviews.Data;

namespace TC_Hackathon_Reviews.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ReviewContext(serviceProvider.GetRequiredService<DbContextOptions<ReviewContext>>()))
            {
                // Look for any ratings.
                if (context.RatingItem.Any()) return; // DB has been seeded

                context.RatingItem.AddRange(
                    new RatingItem
                    {
                        Name = "Excellent"
                    },
                    new RatingItem
                    {
                        Name = "Moderate"
                    },
                    new RatingItem
                    {
                        Name = "Needs Improvement"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}