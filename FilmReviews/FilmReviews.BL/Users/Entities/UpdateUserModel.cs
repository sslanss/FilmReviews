using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Users.Entities
{
    public class UpdateUserModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public List<ReviewModel>? Reviews { get; set; }
        public bool? IsAdmin { get; set; }
        public List<UserRateOnReviewModel>? UserRates { get; set; }
    }
}
