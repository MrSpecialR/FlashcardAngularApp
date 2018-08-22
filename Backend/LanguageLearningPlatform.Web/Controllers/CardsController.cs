namespace LanguageLearningPlatform.Web.Controllers
{
    using Services;
    using BindingModels;
    using Microsoft.AspNetCore.Mvc;


    [Produces("application/json")]
    [Route("cards/[action]")]
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        [HttpGet("{id}")]
        public IActionResult Deck(int id)
        {
            return this.Ok(this.cardsService.GetCardsByDeckId(id));
        }

        [HttpPost("{id}")]
       public IActionResult Create(int id, [FromBody] CardBindingModel cardBindingModel)
       {
           var cardId = this.cardsService.CreateCard(id, cardBindingModel.Word, cardBindingModel.Translation, cardBindingModel.Hint, cardBindingModel.ImageURL);
           return this.Ok(new { Id= cardId, message = "Successfully added word to deck!" });
       }
    }
}