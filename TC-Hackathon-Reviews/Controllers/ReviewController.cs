using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TC_Hackathon_Reviews.Contracts;
using TC_Hackathon_Reviews.Data;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewContext _context;
        private readonly IReviewService _reviewService;

        public ReviewController(ReviewContext context, IReviewService reviewService)
        {
            _context = context;
            _reviewService = reviewService;
        }

        // DELETE: api/ReviewItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReviewItem>> DeleteReviewItem(long id)
        {
            var reviewItem = await _context.ReviewItem.FindAsync(id);
            if (reviewItem == null) return NotFound();

            _context.ReviewItem.Remove(reviewItem);
            await _context.SaveChangesAsync();

            return reviewItem;
        }

        // GET: api/ReviewItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewItem>>> GetReviewItem()
        {
            //return await _context.ReviewItem.ToListAsync();
            return await _reviewService.GetReviewsAsync();
        }

        // GET: api/ReviewItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewItem>> GetReviewItem(long id)
        {
            var reviewItem = await _reviewService.GetReview(id);

            if (reviewItem == null) return NotFound();

            return reviewItem;
        }

        // POST: api/ReviewItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReviewItem>> PostReviewItem(ReviewItem reviewItem)
        {
            if (_reviewService.ReviewItemExists(reviewItem.Id))
                ModelState.AddModelError("", "Item already exists");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reviewService.Add(reviewItem);

            return CreatedAtAction("GetReviewItem", new { id = reviewItem.Id }, reviewItem);
        }

        // PUT: api/ReviewItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewItem(long id, ReviewItem reviewItem)
        {
            if (id != reviewItem.Id) return BadRequest();

            _context.Entry(reviewItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_reviewService.ReviewItemExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }
    }
}