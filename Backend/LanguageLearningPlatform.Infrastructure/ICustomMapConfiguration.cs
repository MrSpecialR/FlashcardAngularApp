namespace LanguageLearningPlatform.Infrastructure
{
    using AutoMapper;

    public interface ICustomMapConfiguration
    {
        void ConfigureMap(Profile profile);
    }
}