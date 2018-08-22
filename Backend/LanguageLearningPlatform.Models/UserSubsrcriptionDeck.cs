namespace LanguageLearningPlatform.Models
{
    public class UserSubsrcriptionDeck
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int DeckId { get; set; }

        public Deck Deck { get; set; }
    }
}