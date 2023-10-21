using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Web.Services.Reviews;

namespace Movies.Web.Controllers;

public class ReviewsController : Controller
{
    private readonly ILogger _logger;
    private readonly IReviewsService _reviewsService;

    public ReviewsController(ILogger<ReviewsController> logger,
                             IReviewsService reviewsService)
    {
        _logger = logger;
        _reviewsService = reviewsService;
    }

    // GET: /reviews/
    public async Task<IActionResult> Index([FromQuery] string? subject)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        IEnumerable<ReviewDto> reviews = null!;
        try
        {
            reviews = await _reviewsService.GetReviewsAsync(subject);
        }
        catch
        {
            _logger.LogWarning("Exception occurred using Reviews service.");
            reviews = Array.Empty<ReviewDto>();
        }
        return View(reviews.ToList());
    }

    // GET: /reviews/details/{id}
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        try
        {
            var review = await _reviewsService.GetReviewAsync(id.Value);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }
        catch
        {
            _logger.LogWarning("Exception occurred using Reviews service.");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
