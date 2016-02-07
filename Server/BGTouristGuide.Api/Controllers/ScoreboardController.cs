namespace BGTouristGuide.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using App_Start;
    using BGTouristGuide.Models;
    using Common.Constants;
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

            for (int i = 0; i < result.Count; i++)
            {
                var currentItem = result[i];

                foreach (var touristSite in currentItem.VisitedTouristSites)
                {
                    if (touristSite.ParentTouristSite.Type == ParentTouristSiteType.GovernemtDefined)
                    {
                        currentItem.CalculatedRating += GlobalConstants.OfficialTouristSiteAwardPoints;
                    }
                    else
                    {
                        currentItem.CalculatedRating += GlobalConstants.UnofficialTouristSiteAwardPoints;
                    }
                }
            }

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<IEnumerable<ScoreboardResponseModel>>(result);

            mappedResult = mappedResult.OrderByDescending(u => u.Rating);

            return this.Json(mappedResult);
        }
    }
}