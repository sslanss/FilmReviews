using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL.Users.Entities;

namespace FilmReviews.WebAPI.Controllers.Entities.Reviews
{
    public class ReviewsListResponse
    {
        public List<ReviewModel>? Reviews { get; set; }
    }
}
