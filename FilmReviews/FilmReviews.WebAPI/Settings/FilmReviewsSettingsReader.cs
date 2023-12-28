namespace FilmReviews.WebAPI.Settings
{
    public class FilmReviewsSettingsReader
    {
        public static FilmReviewsSettings Read(IConfiguration configuration)
        {
            return new FilmReviewsSettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                FilmReviewsDbContextConnectionString = configuration.GetValue<string>("FilmReviewsDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}
