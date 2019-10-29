using Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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

        public IEnumerable<SelectListItem> GetRatingDropdopwn()
        {
            var client = new HttpClient();
            var ratingResult = client.GetAsync<List<Rating>>(BaseUrl + "Rating").Result;
            var ratings = ratingResult.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return new SelectList(ratings, "Value", "Text");
        }
    }
}