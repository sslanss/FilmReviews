namespace FilmReviews.WebAPI.Controllers.Entities.UserRatesOnReviews
{
    public class UserRatesOnReviewsFilter
    {
        public string? UserName { get; set; }
        public string? ReviewTitle { get; set; }
        public int? MinRate { get; set; }
        public int? MaxRate { get; set; }
    }
}
