using System;
using System.Linq;
using System.Net;
using Microsoft.Extensions.Primitives;

namespace LanguageLearningPlatform.Web.Controllers
{
    using Services;
    using BindingModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("decks/[action]")]
    [ApiController]
    public class DecksController : Controller
    {
        private readonly IDecksService decksService;
        private readonly IUsersService usersService;

        public DecksController(IDecksService decksService, IUsersService usersService)
        {
            this.decksService = decksService;
            this.usersService = usersService;
        }
        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            return Ok(this.decksService.GetById(id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] DeckCreationBindingModel deck)
        {
            var id = this.usersService.GetUserId(this.HttpContext.User);
            var deckId = this.decksService.CreateDeck(deck.LanguageFromId, deck.LanguageToId, id, deck.Name, deck.Description, deck.PosterURL, deck.IsPublic);
            return this.Ok(
                new
                {
                    message="Successfully created deck!",
                    id=deckId
                }
            );
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Edit(int id, [FromBody] DeckCreationBindingModel deck)
        {
            var userId = this.usersService.GetUserId(this.HttpContext.User);
            try
            {
                this.decksService.EditDeck(id, deck.LanguageFromId, deck.LanguageToId, userId, deck.Name,
                    deck.Description, deck.PosterURL, deck.IsPublic);
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
            return Ok(
                new
                {
                    message = "Successfully edited deck"
                });
        }

        [HttpGet]
        [Authorize]
        public IActionResult UserDecks()
        {
            var id = this.usersService.GetUserId(this.HttpContext.User);
            return this.Ok(
                this.decksService.GetByUser(id)
            );
        }


        [HttpGet]
        [Authorize]
        public IActionResult UserSubscriptions()
        {
            var id = this.usersService.GetUserId(this.HttpContext.User);
            return this.Ok(
                this.decksService.GetUserSubscriptions(id)
            );
        }

        [HttpPost("{id}")]
        [Authorize]
        public IActionResult Subscribe(int id)
        {
            var userId = this.usersService.GetUserId(this.HttpContext.User);
            try
            {
                this.decksService.SubscribeToDeck(userId, id);
            }
            catch (ArgumentException e)
            {
                return this.BadRequest(
                    new {message = e.Message}
                );
            }
            return this.Ok(new { message = "Subscribed to deck!" });
        }

        [HttpPost("{id}")]
        [Authorize]
        public IActionResult Unsubscribe(int id)
        {
            var userId = this.usersService.GetUserId(this.HttpContext.User);

            try
            {
                this.decksService.UnsubscribeToDeck(userId, id);
            }
            catch (ArgumentException e)
            {
                return this.BadRequest(
                    new { message = e.Message }
                );
            }

            return this.Ok(new { message = "Unsubscribed from deck!" });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Available([FromQuery] string languageFrom, [FromQuery] string languageTo)
        {
            var userId = this.usersService.GetUserId(this.HttpContext.User);


            if (languageFrom != null && languageTo != null)
            {
                return this.Ok(this.decksService.AllFromAndtoLanguage(userId, languageFrom, languageTo));
            }

            if (languageFrom != null)
            {
                return this.Ok(this.decksService.AllFromLanguage(userId, languageFrom));
            }


            if (languageTo != null)
            {
                return this.Ok(this.decksService.AllToLanguage(userId, languageTo));
            }

            return this.Ok(this.decksService.AvailableDecksForUser(userId));
        }
    }
}