using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.UserRates.Entities
{
    public class CreateUserRateOnReviewModel
    {
        public required UserModel User { get; set; }
        public required ReviewModel Review { get; set; }
        public required int Rate { get; set; }
    }
}
