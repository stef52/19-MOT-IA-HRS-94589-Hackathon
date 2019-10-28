using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Contracts
{
    public interface IRatingService
    {
        Task<List<RatingItem>> GetRatings();
        ValueTask<RatingItem> GetRating(long id);
    }
}
