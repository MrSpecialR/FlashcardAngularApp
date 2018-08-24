namespace LanguageLearningPlatform.Services
{
    using System.Collections.Generic;
    using ServiceModels;

    public interface IStatisticsService
    {
        CardUserStatisticsServiceModel GetUserCardStatistics(int deckId, int cardId , string userId);
        IEnumerable<CardUserStatisticsServiceModel> GetUserDeckStatistics(int deckId, string userId);
        IEnumerable<CardUserStatisticsServiceModel> GetUserGlobalStatistics(string userId);
        IEnumerable<CardUserStatisticsServiceModel> GetDeckGlobalStatistics(int deckId);
        IEnumerable<CardUserStatisticsServiceModel> GetCardGlobalStatistics(int cardId);


        void UpdateUserStatisticsForCard(int deckId, int cardId, string userId, bool isSuccessful);
        void UpdateUserStatisticsForCards(IEnumerable<StatisticsUpdateServiceModel> results);

    }
}