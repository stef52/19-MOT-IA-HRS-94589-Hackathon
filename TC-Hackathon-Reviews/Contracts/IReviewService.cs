using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Contracts
{
    public interface IReviewService
    {
        bool ReviewItemExists(long id);
        Task<ActionResult<IEnumerable<ReviewItem>>> GetReviewsAsync();
        ValueTask<ReviewItem> GetReview(long id);
        Task<int> Add(ReviewItem reviewItem);
    }
}
