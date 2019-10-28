using System.Threading.Tasks;
using Client.Models;

namespace Client.Contracts
{
    public interface IReviewService
    {
        void Add(Review review);
        Task<object> GetReview(long? id);
        Task<object> GetReviews();
    }
}