using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.DataAccess.Entities
{
    [Table("user_rates_on_reviews")]
    public class UserRateOnReviewEntity:BaseEntity
    {
        public required UserEntity User { get; set; }
        public required ReviewEntity Review { get; set; }
        public required int Rate {  get; set; }
    }
}
