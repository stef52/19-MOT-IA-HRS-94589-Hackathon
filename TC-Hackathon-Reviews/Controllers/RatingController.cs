using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TC_Hackathon_Reviews.Contracts;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Controllers
{
    [Produces("application/json")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RatingItem>>> GetRatingItem()
        {
            return await _ratingService.GetRatings();
        }

        // GET: api/Rating/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
