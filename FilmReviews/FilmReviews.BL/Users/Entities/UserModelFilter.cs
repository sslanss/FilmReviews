using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Users.Entities
{
    public class UserModelFilter
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? MinReviewsCount { get; set; }
        public int? MaxReviewsCount { get; set; }
        public bool? IsAdmin { get; set; }
        public int? MinRatesCount { get; set; }
        public int? MaxRatesCount { get; set; }
    }
}
