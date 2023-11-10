namespace FilmReviews.WebAPI.Settings
{
    public static class FilmReviewsSettingsReader
    {
        public static FilmReviewsSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new FilmReviewsSettings();
        }
    }
}
