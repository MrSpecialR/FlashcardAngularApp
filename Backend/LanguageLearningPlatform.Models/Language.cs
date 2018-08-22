namespace LanguageLearningPlatform.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Language
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Code { get; set; }
        public IList<Deck> DecksFromLanguage { get; set; } = new List<Deck>();
        public IList<Deck> DecksToLanguage { get; set; } = new List<Deck>();

    }
}