using System;

namespace Movies.Web.Services.Reviews;

public class FakeReviewsService : IReviewsService
{
    private readonly ReviewDto[] _reviews =
    {
            new ReviewDto { Id = 1, AuthorId = "larry", AuthorName = "Larry von Larryington", CategoryId = "MOV", CategoryTitle = "Movie", Subject = "Star Trek", Summary = "Loved it", Text = "Really enjoyed this movie.  Proper good and that.", Rating = 4 },
            new ReviewDto { Id = 2, AuthorId = "beehive", AuthorName = "Betty Lively", CategoryId = "MOV", CategoryTitle = "Movie", Subject = "Star Trek", Summary = "Entertaining but not worth buying", Text = "Didn't feel like the Star Trek I know and love, but it was still entertaining.  Be warned, there's a bit of an obsession with lens flare!", Rating = 3 },
            new ReviewDto { Id = 3, AuthorId = "beehive", AuthorName = "Betty Lively", CategoryId = "MOV", CategoryTitle = "Movie", Subject = "Star Wars: The Force Awakens", Summary = "Please sir, I'd like some more", Text = "Sooo excited to see Star Wars back.  Feels like the Star Wars I grew up with, although perhaps a bit too repetitive from the originals.  Just needs more saber battles!", Rating = 5 },
            new ReviewDto { Id = 4, AuthorId = "larry", AuthorName = "Larry von Larryington", CategoryId = "MOV", CategoryTitle = "Movie", Subject = "Santa Claus Conquers the Martians", Summary = "What!?", Text = "What the actual chuffing missery did I just watch!", Rating = 1 },
            new ReviewDto { Id = 5, AuthorId = "bob69", AuthorName = "Robert Bob Robertson", CategoryId = "MOV", CategoryTitle = "Movie", Subject = "Star Trek", Summary = "wheres mr data???", Text = null, Rating = 2 }

        };

    public Task<ReviewDto> GetReviewAsync(int id)
    {
        var review = _reviews.FirstOrDefault(r => r.Id == id);
        return Task.FromResult(review);
    }

    public Task<IEnumerable<ReviewDto>> GetReviewsAsync(string subject)
    {
        var reviews = _reviews.AsEnumerable();
        if (subject != null)
        {
            reviews = reviews.Where(r => r.Subject.Equals(subject, StringComparison.OrdinalIgnoreCase));
        }
        return Task.FromResult(reviews);
    }
}
