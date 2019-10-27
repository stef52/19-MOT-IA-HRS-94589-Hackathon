using Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services
{
    public class ReviewService : IReviewService
    {
        private const string BaseUrl = "https://api20191027115858.azurewebsites.net/api/";

        public async Task<object> GetReviews()
        {
            var client = new HttpClient();
            return await client.GetAsync<List<Review>>(BaseUrl + "Review");
        }

        public async Task<object> GetReview(long? id)
        {
            var client = new HttpClient();
            return await client.GetAsync<Review>(BaseUrl + "Review/" + id);
        }

        public void Add(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
