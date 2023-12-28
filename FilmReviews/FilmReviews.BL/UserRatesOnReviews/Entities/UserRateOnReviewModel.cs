using FilmReviews.BL.Reviews.Entities;
using FilmReviews.DataAccess.Entities;
using FilmReviews.BL.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.UserRatesOnReviews.Entities
{
    public class UserRateOnReviewModel
    {
        public required Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required UserModel User { get; set; }
        public required ReviewModel Review { get; set; }
        public required int Rate { get; set; }
    }
}
