namespace LanguageLearningPlatform.Services.ServiceModels
{
    public class StatisticsUpdateServiceModel
    {
        public string UserId { get; set; }

        public int DeckId { get; set; }

        public int CardId { get; set; }

        public bool IsSuccessful { get; set; }

        public string CardName { get; set; }

    }
}