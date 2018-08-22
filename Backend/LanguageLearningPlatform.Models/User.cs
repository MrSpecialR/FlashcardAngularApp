namespace LanguageLearningPlatform.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {
        public IList<Deck> UserCreatedDecks { get; set; } = new List<Deck>();

        public IList<UserSubsrcriptionDeck> UserSubscribedDecks { get; set; } = new List<UserSubsrcriptionDeck>();
    }
}
