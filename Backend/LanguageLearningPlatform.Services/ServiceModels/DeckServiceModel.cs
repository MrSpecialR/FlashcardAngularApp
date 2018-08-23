namespace LanguageLearningPlatform.Services.ServiceModels
{
    using AutoMapper;
    using Infrastructure;
    using Models;

    public class DeckServiceModel : ICustomMapConfiguration
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LanguageFrom { get; set; }
        public string LanguageTo { get; set; }

        public string Creator { get; set; }
        public int Subscribers { get; set; }

        public int Cards { get; set; }

        public bool IsPublic { get; set; }

        public string Description { get; set; }

        public string PosterURL { get; set; }

        public bool IsUserSubscribed { get; set; }

        public void ConfigureMap(Profile profile)
        {
            profile.CreateMap<Deck, DeckServiceModel>()
                .ForMember(c => c.LanguageFrom, cfg => cfg.MapFrom(d => d.LanguageFrom.Name))
                .ForMember(c => c.LanguageTo, cfg => cfg.MapFrom(d => d.LanguageTo.Name))
                .ForMember(c => c.Subscribers, cfg => cfg.MapFrom(d => d.Subscribers.Count))
                .ForMember(c => c.Cards, cfg => cfg.MapFrom(d => d.Cards.Count))
                .ForMember(c => c.Creator, cfg => cfg.MapFrom(d => d.Creator.UserName));
        }
    }
}