using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TC_Hackathon_Reviews.Contracts;
using TC_Hackathon_Reviews.Data;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ReviewContext _context;
        private readonly IRatingService _ratingService;

        public ReviewService(ReviewContext context, IRatingService ratingService)
        {
            _context = context;
            _ratingService = ratingService;
        }

        public bool ReviewItemExists(long id)
        {
            return _context.ReviewItem.Any(e => e.Id == id);
        }

        public async Task<ActionResult<IEnumerable<ReviewItem>>> GetReviewsAsync()
        {
            return await _context.ReviewItem.ToListAsync();
        }

        public ValueTask<ReviewItem> GetReview(long id)
        {
            return _context.ReviewItem.FindAsync(id);
        }

        public async Task<int> Add(ReviewItem reviewItem)
        {
            var rating = _ratingService.GetRating(reviewItem.Rating.Id);
            //TODO make sure not null
            reviewItem.Rating = await rating;
            _context.ReviewItem.Add(reviewItem);
            return await _context.SaveChangesAsync();
        }
    }
}
