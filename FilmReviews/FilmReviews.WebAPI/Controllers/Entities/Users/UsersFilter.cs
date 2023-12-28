namespace FilmReviews.WebAPI.Controllers.Entities.Users
{
    public class UsersFilter
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
