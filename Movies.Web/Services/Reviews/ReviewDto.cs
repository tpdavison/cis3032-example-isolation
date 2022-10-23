using System;

namespace Movies.Web.Services.Reviews;

public class ReviewDto
{
    public int Id { get; set; }

    public string AuthorId { get; set; }

    public string AuthorName { get; set; }

    public string CategoryId { get; set; }

    public string CategoryTitle { get; set; }

    public string Subject { get; set; }

    public string Summary { get; set; }

    public string Text { get; set; }

    public int Rating { get; set; }
}
