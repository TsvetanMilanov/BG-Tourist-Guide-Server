namespace BGTouristGuide.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using App_Start;

    using Models.ResponseModels.TouristSites;
    using Services.Contracts;
    using BGTouristGuide.Models;
    [RoutePrefix("api/TouristSites")]
    public class TouristSitesController : ApiController
    {
        private ITouristSitesServices touristSites;

        public TouristSitesController(ITouristSitesServices touristSites)
        {
            this.touristSites = touristSites;
        }

        public IHttpActionResult Get()
        {
            var result = this.touristSites.GetAll();

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<IEnumerable<FullTouristSiteResponseModel>>(result);

            return this.Json(mappedResult);
        }

        [HttpGet]
        [Route("Parents/Simple")]
        public IHttpActionResult GetSimpleParentTouristSites(int page = 1, ParentTouristSiteType type = 0)
        {
            var result = this.touristSites.GetParentTouristSites(page - 1, (int)type);

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<IEnumerable<SimpleParentTouristSiteResponseModel>>(result);

            return this.Ok(mappedResult);
        }

        [HttpGet]
        [Route("Simple")]
        public IHttpActionResult GetSimpleTouristSitesInformation(int id)
        {
            var result = this.touristSites.GetByParentTouristSiteId(id);

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<IEnumerable<SimpleTouristSiteResponseModel>>(result);

            return this.Ok(mappedResult);
        }
    }
}