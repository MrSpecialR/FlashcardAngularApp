namespace LanguageLearningPlatform.Services.ServiceModels
{
    using Infrastructure;
    using Models;

    public class LanguageServiceModel : IMappableFrom<Language>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}