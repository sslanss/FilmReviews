using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.BL.Users.Entities;

namespace FilmReviews.WebAPI.Controllers.Entities.UserRatesOnReviews
{
    public class UserRatesOnReviewsListResponse
    {
        public List<UserRateOnReviewModel>? UserRates { get; set; }
    }
}
