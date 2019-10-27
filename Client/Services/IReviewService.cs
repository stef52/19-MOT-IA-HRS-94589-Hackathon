using Client.Models;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IReviewService
    {
        Task<object> GetReviews();
        Task<object> GetReview(long? id);
        void Add(Review review);
    }
}
