using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Client.Contracts
{
    public interface IReviewService
    {
        void Add(Review review);
        Task<object> GetReview(long? id);
        Task<object> GetReviews();
        IEnumerable<SelectListItem> GetRatingDropdopwn();
    }
}