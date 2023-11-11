using System;

namespace Movies.Api.Services.Reviews;

public interface IReviewsService
{
    Task<IEnumerable<ReviewDto>> GetReviewsAsync(string? subject);

    Task<ReviewDto?> GetReviewAsync(int id);
}
