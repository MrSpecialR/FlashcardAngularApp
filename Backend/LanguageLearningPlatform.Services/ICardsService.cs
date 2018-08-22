namespace LanguageLearningPlatform.Services
{
    using ServiceModels;
    using System.Collections.Generic;

    public interface ICardsService
    {
        CardServiceModel GetCardById(int id);

        IEnumerable<CardServiceModel> GetCardsByDeckId(int deckId);

        int CreateCard(int deckId, string word, string translation, string hint, string imageUrl);
    }
}