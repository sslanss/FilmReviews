using FilmReviews.BL.Reviews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.UserRatesOnReviews.Entities
{
    public class UserRateOnReviewModelFilter
    {
        public string? UserName { get; set; }
        public string? ReviewTitle { get; set; }
        public int? MinRate { get; set; }
        public int? MaxRate { get; set; }
    }
}
