namespace BGTouristGuide.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using App_Start;

    using Models.ResponseModels.TouristSites;
    using Services.Contracts;

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
    }
}