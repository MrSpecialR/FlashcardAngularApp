using System.Collections.Generic;
using System.Linq;
using LanguageLearningPlatform.Models;
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

            var statisticsUpdateServiceModels = statistics as StatisticsUpdateServiceModel[] ?? statistics.ToArray();

            if (statisticsUpdateServiceModels[0].UserId == null)
            {
                var userId = this.usersService.GetUserId(this.HttpContext.User);

                statisticsUpdateServiceModels = statisticsUpdateServiceModels.Where(s => s.UserId == null).Select(s =>
                {
                    s.UserId = userId;
                    return s;
                }).ToArray();
            }

            if (statisticsUpdateServiceModels.Count() == 1)
            {
                var statistic = statisticsUpdateServiceModels.First();
                this.statisticsService.UpdateUserStatisticsForCard(statistic.DeckId, statistic.CardId, statistic.UserId, statistic.IsSuccessful);
                return this.Ok(new
                {
                    results = new []
                    {
                        new Statistic
                        {
                            CardId = statistic.CardId,
                            CheckedTimes = 1,
                            CorrectTimes = statistic.IsSuccessful ? 1 : 0,
                            UserId = statistic.UserId,
                            DeckId = statistic.DeckId,
                            Card = new Card
                            {
                                Word = statistic.CardName
                            }
                        }
                    },
                    message = "Successfully uploaded results!"
                });
            }
            this.statisticsService.UpdateUserStatisticsForCards(statisticsUpdateServiceModels);

            IDictionary<int, Statistic> statisticsResults = new Dictionary<int, Statistic>();

            foreach (var statistic in statisticsUpdateServiceModels)
            {
                if (!statisticsResults.ContainsKey(statistic.CardId))
                {
                    statisticsResults.Add(statistic.CardId, new Statistic
                    {
                        CardId = statistic.CardId,
                        CheckedTimes = 0,
                        CorrectTimes = 0,
                        UserId = statistic.UserId,
                        DeckId = statistic.DeckId,
                        Card = new Card
                        {
                            Word = statistic.CardName
                        }
                    });
                }

                statisticsResults[statistic.CardId].CheckedTimes++;
                if (statistic.IsSuccessful)
                {
                    statisticsResults[statistic.CardId].CorrectTimes++;
                }
            }



            return this.Ok(new
            {
                message = "Successfully uploaded results!",
                results = statisticsResults.Values.Select(s => new
                {
                    CardId = s.CardId,
                    CheckedTimes = s.CheckedTimes,
                    CorrectTimes = s.CorrectTimes,
                    UserId = s.UserId,
                    DeckId = s.DeckId,
                    Card = s.Card,
                    Accuracy = 100.0M * s.CorrectTimes / s.CheckedTimes
            }).ToArray()
            });
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