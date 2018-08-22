namespace LanguageLearningPlatform.Services.ServiceModels
{
    using Infrastructure;
    using Models;

    public class CardServiceModel : IMappableFrom<Card>
    {
        public int Id { get; set; }

        public string Word { get; set; }

        public string Translation { get; set; }

        public string Hint { get; set; }

        public string ImageUrl { get; set; }
    }
}