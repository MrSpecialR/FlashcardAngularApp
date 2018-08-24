namespace LanguageLearningPlatform.Services
{
    using System.Collections.Generic;
    using ServiceModels;

    public interface IDecksService
    {
        DeckServiceModel GetById(int id, string userId);

        IEnumerable<DeckServiceModel> GetByUser(string userId);

        IEnumerable<DeckServiceModel> All();

        IEnumerable<DeckServiceModel> AllFromAndtoLanguage(string userId, string languageFrom, string languageTo);
        IEnumerable<DeckServiceModel> AllFromLanguage(string userId, string language);
        IEnumerable<DeckServiceModel> AllToLanguage(string userId, string language);
        IEnumerable<DeckServiceModel> AvailableDecksForUser(string userId);

        IEnumerable<DeckServiceModel> GetUserSubscriptions(string userId);

        void SubscribeToDeck(string userId, int deckId);

        void UnsubscribeToDeck(string userId, int deckId);
        int CreateDeck(int languageFromId, int languageToId, string creatorId, string name, string description, string posterUrl,
            bool isPublic = false);

        int EditDeck(int deckId, int languageFromId, int languageToId, string userId, string name, string description, string posterUrl,
            bool isPublic = false);

        void DeleteDeck(int id, string userId);
    }
}