using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TC_Hackathon_Reviews.Contracts;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        // GET: api/Rating
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingItem>>> GetRatingItem()
        {
            return await _ratingService.GetRatings();
        }

        // GET: api/Rating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RatingItem>> GetRatingItem(long id)
        {
            var ratingItem = await _ratingService.GetRating(id);

            if (ratingItem == null)
            {
                return NotFound();
            }

            return ratingItem;
        }

    }
}
