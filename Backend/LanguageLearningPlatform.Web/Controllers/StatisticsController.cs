using System.Collections.Generic;
using System.Linq;
using LanguageLearningPlatform.Services;
using LanguageLearningPlatform.Services.ServiceModels;
using Microsoft.AspNetCore.Authorization;

namespace LanguageLearningPlatform.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("statistics/[action]")]
    [ApiController]
    public class StatisticsController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IStatisticsService statisticsService;
        public StatisticsController(IUsersService userService, IStatisticsService statisticsService)
        {
            this.usersService = userService;
            this.statisticsService = statisticsService;
        }

       // [HttpPost]
       // [Authorize]
       // public IActionResult Upload([FromBody] StatisticsUpdateServiceModel statistic)
       // {
       //     this.statisticsService.UpdateUserStatisticsForCard(statistic.DeckId, statistic.CardId, /statistic.UserId, /statistic.IsSuccessful);
       //     return this.Ok();
       // }

        [HttpPost]
        [Authorize]
        public IActionResult Upload([FromBody] IEnumerable<StatisticsUpdateServiceModel> statistics)
        {
            if (statistics == null)
            {
                return this.BadRequest(new
                {
                    message = "No data to upload"
                });
            }
            if (statistics.Count() == 1)
            {
                var statistic = statistics.First();
                this.statisticsService.UpdateUserStatisticsForCard(statistic.DeckId, statistic.CardId, statistic.UserId, statistic.IsSuccessful);
                return this.Ok();
            }
            this.statisticsService.UpdateUserStatisticsForCards(statistics);
            return this.Ok();
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Deck(int id)
        {
            return this.Ok(this.statisticsService.GetDeckGlobalStatistics(id));
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Card(int id)
        {
            return this.Ok(this.statisticsService.GetCardGlobalStatistics(id));
        }

        [Authorize]
        [HttpGet("{username}")]
        public IActionResult User(string username)
        {
            var id = this.usersService.GetUserId(username);
            return this.Ok(this.statisticsService.GetUserGlobalStatistics(id));
        }
    }
}