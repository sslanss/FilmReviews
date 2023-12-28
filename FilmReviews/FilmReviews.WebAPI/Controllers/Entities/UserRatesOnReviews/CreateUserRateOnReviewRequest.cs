using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL.Users.Entities;
using System.ComponentModel.DataAnnotations;

namespace FilmReviews.WebAPI.Controllers.Entities.UserRatesOnReviews
{
    public class CreateUserRateOnReviewRequest 
    {
        public required UserModel User { get; set; }
        public required ReviewModel Review { get; set; }
        public required int Rate { get; set; }
    }
}
