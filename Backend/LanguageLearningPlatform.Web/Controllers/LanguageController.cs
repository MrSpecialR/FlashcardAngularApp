using LanguageLearningPlatform.Services;
using LanguageLearningPlatform.Web.BindingModels;
using Microsoft.AspNetCore.Authorization;

namespace LanguageLearningPlatform.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("languages/[action]")]
    public class LanguageController : Controller
    {
        private readonly ILanguageService languages;

        public LanguageController(ILanguageService languages)
        {
            this.languages = languages;
        }
        [HttpGet]
        public IActionResult All()
        {
            return this.Ok(this.languages.All());
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create([FromBody] LanguageBindingModel language)
        {
            this.languages.Create(language.Name, language.Code);
            return this.Ok(new
            {
                message = "Successfully created language!"
            });
        }
    }

}