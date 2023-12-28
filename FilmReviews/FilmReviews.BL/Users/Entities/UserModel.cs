using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Users.Entities
{
    public class UserModel
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public List<ReviewModel>? Reviews { get; set; }
        public required bool IsAdmin { get; set; }
        public List<UserRateOnReviewModel>? UserRates { get; set; }
    }
}
