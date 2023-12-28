using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FilmReviews.WebAPI.Controllers.Entities.Users
{
    public class UpdateUserRequest : IValidatableObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<ReviewModel>? Reviews { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserRateOnReviewModel>? UserRates { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add(new ValidationResult($"{nameof(Name)} must have at least 1 character."));
            }

            if (string.IsNullOrWhiteSpace(Surname))
            {
                errors.Add(new ValidationResult($"{nameof(Surname)} must have at least 1 character."));
            }

            if (!IsValidEmail())
            {
                errors.Add(new ValidationResult($"{nameof(Email)} is invalid."));
            }

            return errors;
        }

        private bool IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                return false;
            }

            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Regex regex = new(emailPattern, RegexOptions.Compiled);

            return regex.IsMatch(Email);
        }
    }
}
