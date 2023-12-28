using FilmReviews.DataAccess.Entities;

namespace FilmReviews.WebAPI.Controllers.Entities.Reviews
{
    public class ReviewsFilter
    {
        public string? UserName { get; set; }
        public string? FilmName { get; set; }
        public string? Title { get; set; }
        public ReviewEntity.ReviewStatus? Status { get; set; }
    }
}
