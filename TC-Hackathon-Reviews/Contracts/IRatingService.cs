using System.Collections.Generic;
using System.Threading.Tasks;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Contracts
{
    public interface IRatingService
    {
        ValueTask<RatingItem> GetRating(long id);
        Task<List<RatingItem>> GetRatings();
    }
}