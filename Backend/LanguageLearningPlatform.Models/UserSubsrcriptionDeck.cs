namespace LanguageLearningPlatform.Models
{
    using System.Collections.Generic;

    public class UserSubsrcriptionDeck
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int DeckId { get; set; }

        public Deck Deck { get; set; }

        public IList<Statistic> Statistics { get; set; } = new List<Statistic>();
    }
}