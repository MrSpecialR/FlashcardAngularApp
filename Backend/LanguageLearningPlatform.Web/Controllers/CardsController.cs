using System;
using LanguageLearningPlatform.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;

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
        private readonly IUsersService usersService;


        public CardsController(ICardsService cardsService, IUsersService usersService)
        {
            this.cardsService = cardsService;
            this.usersService = usersService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Deck(int id)
        {
            var userId = this.usersService.GetUserId(this.HttpContext.User);


            try
            {
                return this.Ok(this.cardsService.GetCardsByDeckId(id, userId));
            }
            catch (ArgumentException e)
            {
                return this.BadRequest(new
                {
                    message = e.Message
                });
            }
            catch (AuthorizationException e)
            {
                return this.StatusCode(401, new
                {
                    message = e.Message
                });
            }
        }

        [HttpPost("{id}")]
        [Authorize]
       public IActionResult Create(int id, [FromBody] CardBindingModel cardBindingModel)
        {
           var userId = this.usersService.GetUserId(this.HttpContext.User);
            try
            {
                var cardId = this.cardsService.CreateCard(id, userId, cardBindingModel.Word,
                    cardBindingModel.Translation, cardBindingModel.Hint, cardBindingModel.ImageURL);

                return this.Ok(new {Id = cardId, message = "Successfully added word to deck!"});
            }
            catch (AuthorizationException e)
            {
                return this.StatusCode(401, new
                {
                    message = e.Message
                });
            }
       }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Details(int id)
        {
            var userId = this.usersService.GetUserId(this.HttpContext.User);
            return this.Ok(this.cardsService.GetCardById(id, userId));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userId = this.usersService.GetUserId(this.HttpContext.User);
            return this.Ok(this.cardsService.GetCardById(id, userId));
        }
    }
}