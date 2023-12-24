using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.DataAccess.Entities
{
    public class UserEntity:BaseEntity
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public virtual ICollection<ReviewEntity>? Reviews { get; set; }
        public required bool IsAdmin { get; set; }
        public virtual ICollection<UserRateOnReviewEntity>? UserRates { get; set; }
    }
}
