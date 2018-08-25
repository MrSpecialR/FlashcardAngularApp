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
            try
            {
                var card = this.cardsService.GetCardById(id, userId);
                return this.Ok(card);
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


        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Edit(int id, [FromBody] CardBindingModel cardBindingModel)
        {
            var userId = this.usersService.GetUserId(this.HttpContext.User);
            try
            {
                int deckId = this.cardsService.EditCard(id, userId, cardBindingModel.Word,
                    cardBindingModel.Translation, cardBindingModel.Hint, cardBindingModel.ImageURL);


                return Ok(
                    new
                    {
                        id = deckId,
                        message = "Successfully edited card!"
                    });
            }
            catch (ArgumentException e)
            {
                return this.NotFound(new
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

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var userId = this.usersService.GetUserId(this.HttpContext.User);
            var deckId = this.cardsService.DeleteCard(id, userId);
            return this.Ok(new
            {
                id = deckId,
                message = "Successfully deleted card!"
            });
        }
    }
}