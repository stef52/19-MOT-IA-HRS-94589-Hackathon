using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _service;

        public ReviewsController(IReviewService service)
        {
            _service = service;
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            var model = new ReviewViewModel
            {
                RatingDropdown = _service.GetRatingDropdopwn()
            };
            return View(model);
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comment,RatingId")] ReviewViewModel review)
        {
            if (ModelState.IsValid)
            {
                _service.Add(review);
                return RedirectToAction(nameof(Index));
            }

            return View(review);
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null) return NotFound();

            var review = await _service.GetReview(id);
            if (review == null) return NotFound();

            return View(ReviewToViewModel((Review)review));
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var revs = await _service.GetReviews();

            var vms = (from rev in (List<Review>)revs select ReviewToViewModel(rev)).ToList();

            return View(vms);
        }

        private ReviewViewModel ReviewToViewModel(Review review)
        {
            var vm = new ReviewViewModel
            {
                Id = review.Id,
                Comment = review.Comment,
                RatingId = review.RatingId,
                RatingDropdown = _service.GetRatingDropdopwn()
            };
            vm.RatingName = vm.RatingDropdown.First(x => x.Value == vm.RatingId.ToString()).Text;

            return vm;
        }
    }
}