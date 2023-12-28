using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Reviews.Entities
{
    public class UpdateReviewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ReviewEntity.ReviewStatus Status { get; set; }
        public List<UserRateOnReviewModel>? UserRates { get; set; }
    }
}
