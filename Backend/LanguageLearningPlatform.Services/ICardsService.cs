namespace LanguageLearningPlatform.Services
{
    using ServiceModels;
    using System.Collections.Generic;

    public interface ICardsService
    {
        CardServiceModel GetCardById(int id, string userId);

        IEnumerable<CardServiceModel> GetCardsByDeckId(int deckId, string userId);

        int CreateCard(int deckId, string userId, string word, string translation, string hint, string imageUrl);
    }
}