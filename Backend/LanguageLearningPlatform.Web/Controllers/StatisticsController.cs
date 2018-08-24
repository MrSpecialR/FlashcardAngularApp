using System.Collections.Generic;
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

        [HttpPost]
        [Authorize]
        public IActionResult UploadStatistic([FromBody] StatisticsUpdateServiceModel statistic)
        {
            this.statisticsService.UpdateUserStatisticsForCard(statistic.DeckId, statistic.CardId, statistic.UserId, statistic.IsSuccessful);
            return this.Ok();
        }

        [HttpPost]
        [Authorize]
        public IActionResult UploadStatistics([FromBody] IEnumerable<StatisticsUpdateServiceModel> statistics)
        {
            this.statisticsService.UpdateUserStatisticsForCards(statistics);
            return this.Ok();
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetDeckStatistics(int id)
        {
            return this.Ok(this.statisticsService.GetDeckGlobalStatistics(id));
        }
    }
}