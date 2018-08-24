using System;

namespace LanguageLearningPlatform.Models
{
    public class Statistic
    {
        public int DeckId { get; set; }

        public string UserId { get; set; }

        public UserSubsrcriptionDeck Subscription { get; set; }

        public int CardId { get; set; }

        public Card Card { get; set; }

        public DateTime? LastCheckedOn { get; set; }

        public int CheckedTimes { get; set; }

        public int CorrectTimes { get; set; }
    }
}