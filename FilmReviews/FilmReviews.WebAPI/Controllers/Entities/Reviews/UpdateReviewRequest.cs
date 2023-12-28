using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.DataAccess.Entities;

namespace FilmReviews.WebAPI.Controllers.Entities.Reviews
{
    public class UpdateReviewRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ReviewEntity.ReviewStatus Status { get; set; }
        public List<UserRateOnReviewModel>? UserRates { get; set; }
    }
}
