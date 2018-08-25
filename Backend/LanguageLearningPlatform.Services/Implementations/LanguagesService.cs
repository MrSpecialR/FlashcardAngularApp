namespace LanguageLearningPlatform.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using LanguageLearningPlatform.Data;
    using LanguageLearningPlatform.Services.ServiceModels;
    using AutoMapper;
    using Models;

    public class LanguagesService : ILanguageService
    {
        private readonly LearningContext db;
        private IMapper mapper;

        public LanguagesService(LearningContext context, IMapper mapper)
        {
            this.db = context;
            this.mapper = mapper;
        }

        public IEnumerable<LanguageServiceModel> All()
        {
            return this.db.Languages.OrderBy(l => l.Name).Select(l => this.mapper.Map<Language, LanguageServiceModel>(l)).ToList();
        }

        public void Create(string name, string code)
        {
            this.db.Languages.Add(new Language
                {
                    Code = code,
                    Name = name
                }
            );
            this.db.SaveChanges();
        }
    }
}