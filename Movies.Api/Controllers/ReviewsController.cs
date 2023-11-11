using Microsoft.AspNetCore.Mvc;
using Movies.Api.Services.Reviews;

namespace Movies.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : ControllerBase
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
    // GET: /reviews?subject=bob
    [HttpGet]
    public async Task<IActionResult> FindReviewsBySubject([FromQuery] string? subject)
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
        return Ok(reviews.ToList());
    }

    // GET: /reviews/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReviewById([FromRoute]int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var review = await _reviewsService.GetReviewAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        catch
        {
            _logger.LogWarning("Exception occurred using Reviews service.");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    // DELETE: /reviews/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReviewById([FromRoute]int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _reviewsService.DeleteReviewAsync(id);
            return Ok();
        }
        catch
        {
            _logger.LogWarning("Exception occurred using Reviews service.");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
