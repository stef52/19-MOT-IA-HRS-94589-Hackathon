using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TC_Hackathon_Reviews.Contracts;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/ReviewItems
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReviewItem>>> GetReviewItem()
        {
            return await _reviewService.GetReviewsAsync();
        }

        // GET: api/ReviewItems/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewItem>> GetReviewItem(long id)
        {
            var reviewItem = await _reviewService.GetReview(id);

            if (reviewItem == null) return NotFound();

            return reviewItem;
        }

        // POST: api/ReviewItems
        /// <summary>
        ///     Creates a Review.
        /// </summary>
        /// <returns>A newly created Review</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReviewItem>> PostReviewItem(ReviewItem reviewItem)
        {
            if (_reviewService.ReviewItemExists(reviewItem.Id))
                ModelState.AddModelError("", "Item already exists");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var saved = await _reviewService.Add(reviewItem);

            if (saved == 0)
            {
                ModelState.AddModelError("", "Please select a valid rating");
                return BadRequest(ModelState);
            }

            return CreatedAtAction("GetReviewItem", new { id = reviewItem.Id }, reviewItem);
        }
    }
}