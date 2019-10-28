using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TC_Hackathon_Reviews.Contracts;
using TC_Hackathon_Reviews.Data;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Services
{
    public class RatingService : IRatingService
    {
        private readonly ReviewContext _context;

        public RatingService(ReviewContext context)
        {
            _context = context;
        }

        public Task<List<RatingItem>> GetRatings()
        {
            return _context.RatingItem.ToListAsync();
        }

        public ValueTask<RatingItem> GetRating(long id)
        {
            return _context.RatingItem.FindAsync(id);
        }
    }
}
