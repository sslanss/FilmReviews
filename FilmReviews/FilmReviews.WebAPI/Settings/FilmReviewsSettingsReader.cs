namespace FilmReviews.WebAPI.Settings
{
    public class FilmReviewsSettingsReader
    {
        public static FilmReviewsSettings Read(IConfiguration configuration)
        {
            return new FilmReviewsSettings()
            {
                FilmReviewsDbContextConnectionString = configuration.GetValue<string>("FilmReviewsDbContext")
            };
        }
    }
}
