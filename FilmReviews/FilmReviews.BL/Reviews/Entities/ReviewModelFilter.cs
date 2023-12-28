using FilmReviews.BL.Films.Entities;
using FilmReviews.DataAccess.Entities;
using FilmReviews.BL.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Reviews.Entities
{
    public class ReviewModelFilter
    {
        public string? UserName { get; set; }
        public string? FilmName { get; set; }
        public string? Title { get; set; }
        public ReviewEntity.ReviewStatus? Status { get; set; }
    }
}
