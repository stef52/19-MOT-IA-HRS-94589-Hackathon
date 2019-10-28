using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var rating = await _ratingService.GetRating(reviewItem.RatingId);

            if (rating == null)
            {
                return 0;
            }

            _context.ReviewItem.Add(reviewItem);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
