namespace FilmReviews.WebAPI.Settings
{
    public static class FilmReviewsSettingsReader
    {
        public static FilmReviewsSettings Read(IConfiguration configuration)
        {
            return new FilmReviewsSettings();
        }
    }
}
