using System;

namespace Movies.Web.Services.Reviews;

public class ReviewDto
{
    public int Id { get; set; }

    public string AuthorId { get; set; } = string.Empty;

    public string AuthorName { get; set; } = string.Empty;

    public string CategoryId { get; set; } = string.Empty;

    public string CategoryTitle { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public int Rating { get; set; }
}
