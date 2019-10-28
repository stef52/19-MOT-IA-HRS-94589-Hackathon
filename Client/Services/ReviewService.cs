using Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Contracts;

namespace Client.Services
{
    public class ReviewService : IReviewService
    {
        private const string BaseUrl = "https://api20191027115858.azurewebsites.net/api/";

        public async void Add(Review review)
        {
            var client = new HttpClient();
            await client.PostAsync<Review, Review>(BaseUrl + "Review", review);
        }

        public async Task<object> GetReview(long? id)
        {
            var client = new HttpClient();
            return await client.GetAsync<Review>(BaseUrl + "Review/" + id);
        }

        public async Task<object> GetReviews()
        {
            var client = new HttpClient();
            return await client.GetAsync<List<Review>>(BaseUrl + "Review");
        }
    }
}