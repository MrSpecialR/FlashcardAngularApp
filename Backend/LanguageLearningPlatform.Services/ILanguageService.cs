﻿namespace LanguageLearningPlatform.Services
{
    using System.Collections.Generic;
    using LanguageLearningPlatform.Services.ServiceModels;

    public interface ILanguageService
    {
        IEnumerable<LanguageServiceModel> All();

        void Create(string name, string code);

    }
}