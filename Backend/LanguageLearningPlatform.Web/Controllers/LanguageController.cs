using LanguageLearningPlatform.Services;

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
    }
}