namespace BGTouristGuide.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using App_Start;
    using Models.ResponseModels.Common;
    using Services.Contracts;

    public class ScoreboardController : ApiController
    {
        IScoreboardServices scoreboard;

        public ScoreboardController(IScoreboardServices scoreboard)
        {
            this.scoreboard = scoreboard;
        }

        public IHttpActionResult Get()
        {
            var result = this.scoreboard.GetUsersScoreboard().ToList();

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<IEnumerable<ScoreboardResponseModel>>(result);

            return this.Json(mappedResult);
        }
    }
}