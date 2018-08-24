using System;

namespace LanguageLearningPlatform.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deck
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string PosterURL { get; set; }

        public IList<Card> Cards { get; set; }

        public int LanguageFromId { get; set; }

        public Language LanguageFrom { get; set; }


        public int LanguageToId { get; set; }

        public Language LanguageTo { get; set; }

        public IList<UserSubsrcriptionDeck> Subscribers { get; set; } = new List<UserSubsrcriptionDeck>();

        public string CreatorId { get; set; }
        public User Creator { get; set; }

        public bool IsPublic { get; set; }

        public DateTime DateOfCreation { get; set; }      
    }
}