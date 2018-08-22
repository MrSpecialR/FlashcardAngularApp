namespace LanguageLearningPlatform.Web.BindingModels
{
    public class DeckCreationBindingModel
    {
        public int LanguageToId { get; set; }

        public int LanguageFromId { get; set; }

        public string Name { get; set; }
        public bool IsPublic { get; set; }

        public string PosterURL { get; set; }

        public string Description { get; set; }
    }
}