using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TC_Hackathon_Reviews.Data;
using TC_Hackathon_Reviews.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly RatingContext _context;

        public RatingController(RatingContext context)
        {
            _context = context;
        }

        // GET: api/Rating
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingItem>>> GetRatingItem()
        {
            return await _context.RatingItem.ToListAsync();
        }

        // GET: api/Rating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RatingItem>> GetRatingItem(long id)
        {
            var ratingItem = await _context.RatingItem.FindAsync(id);

            if (ratingItem == null)
            {
                return NotFound();
            }

            return ratingItem;
        }

    }
}
