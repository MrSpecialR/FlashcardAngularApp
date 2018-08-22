namespace LanguageLearningPlatform.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Card
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public Deck Deck { get; set; }

        [Required]
        public string Word { get; set; }

        [Required]
        public string Translation { get; set; }

        public string Hint { get; set; }

        public string ImageUrl { get; set; }
    }
}