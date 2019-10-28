using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TC_Hackathon_Reviews.Contracts;
using TC_Hackathon_Reviews.Data;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Services
{
    public class RatingService : IRatingService
    {
        private readonly RatingContext _context;

        public RatingService(RatingContext context)
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
