using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TC_Hackathon_Reviews.Models;

namespace TC_Hackathon_Reviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewItemsController : ControllerBase
    {
        private readonly ReviewContext _context;

        public ReviewItemsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: api/ReviewItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewItem>>> GetReviewItem()
        {
            return await _context.ReviewItem.ToListAsync();
        }

        // GET: api/ReviewItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewItem>> GetReviewItem(long id)
        {
            var reviewItem = await _context.ReviewItem.FindAsync(id);

            if (reviewItem == null)
            {
                return NotFound();
            }

            return reviewItem;
        }

        // PUT: api/ReviewItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewItem(long id, ReviewItem reviewItem)
        {
            if (id != reviewItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(reviewItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReviewItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ReviewItem>> PostReviewItem(ReviewItem reviewItem)
        {
            _context.ReviewItem.Add(reviewItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReviewItem", new { id = reviewItem.Id }, reviewItem);
        }

        // DELETE: api/ReviewItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReviewItem>> DeleteReviewItem(long id)
        {
            var reviewItem = await _context.ReviewItem.FindAsync(id);
            if (reviewItem == null)
            {
                return NotFound();
            }

            _context.ReviewItem.Remove(reviewItem);
            await _context.SaveChangesAsync();

            return reviewItem;
        }

        private bool ReviewItemExists(long id)
        {
            return _context.ReviewItem.Any(e => e.Id == id);
        }
    }
}
