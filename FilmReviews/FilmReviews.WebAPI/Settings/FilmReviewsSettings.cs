namespace FilmReviews.WebAPI.Settings
{
    public class FilmReviewsSettings
    {
        public required Uri ServiceUri { get; set; }
        public required string FilmReviewsDbContextConnectionString { get; set; }
        public required string IdentityServerUri { get; set; }
        public required string ClientId { get; set; }
        public required string ClientSecret { get; set; }
    }
}
