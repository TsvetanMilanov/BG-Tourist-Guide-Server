namespace BGTouristGuide.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using App_Start;

    using Models.ResponseModels.TouristSites;
    using Services.Contracts;
    using BGTouristGuide.Models;
    using Models.RequestModels.TouristSites;
    using Microsoft.AspNet.Identity;
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
        [Route("Parents")]
        public IHttpActionResult GetParentTouristSiteById(int id)
        {
            var result = this.touristSites.GetParentTouristSiteById(id);

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<FullTouristSiteResponseModel>(result);

            return this.Ok(mappedResult);
        }

        [HttpGet]
        [Route("Simple")]
        public IHttpActionResult GetSimpleTouristSitesInformation(int id)
        {
            var result = this.touristSites.GetByParentTouristSiteId(id);

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<IEnumerable<SimpleTouristSiteResponseModel>>(result);

            return this.Json(mappedResult);
        }

        [HttpGet]
        [Route("ForRating")]
        public IHttpActionResult GetTouristSitesForRating(int page = 1)
        {
            var result = this.touristSites.GetTouristSitesForRating(page - 1);

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<IEnumerable<TouristSiteResponseModel>>(result);

            return this.Json(mappedResult);
        }

        [HttpGet]
        [Route("ForApproving")]
        public IHttpActionResult GetTouristSitesForApproving(int page = 1)
        {
            var result = this.touristSites.GetTouristSitesForApproving(page - 1);

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<IEnumerable<TouristSiteResponseModel>>(result);

            return this.Json(mappedResult);
        }

        [HttpGet]
        [Route("NearMe")]
        public IHttpActionResult GetTouristSitesNearMe(double latitude, double longitude, int page = 1)
        {
            var result = this.touristSites.GetTouristSitesNearMe(latitude, longitude, page - 1);

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<IEnumerable<TouristSiteResponseModel>>(result);

            return this.Json(mappedResult);
        }

        [Authorize]
        [HttpPost]
        [Route("Visit")]
        public IHttpActionResult VisitTouristSite(int id)
        {
            this.touristSites.VisitTouristSite(this.User.Identity.GetUserId(), id);

            return this.Ok();
        }

        [HttpPost]
        [Route("Parents")]
        public IHttpActionResult AddParentTouristSite(ParentTouristSiteRequestModel model)
        {
            var result = this.touristSites.AddParentTouristSite(model.Name, model.Description, model.Type);

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<SimpleParentTouristSiteResponseModel>(result);

            return this.Json(mappedResult);
        }

        [HttpPost]
        public IHttpActionResult AddTouristSite(TouristSiteRequestModel model)
        {
            var result = this.touristSites.AddTouristSite(
                model.Name,
                model.Description,
                model.Address,
                model.Latitude,
                model.Longitude,
                model.ParentTouristSiteId);

            var mapper = AutoMapperConfig.MapperConfig.CreateMapper();

            var mappedResult = mapper.Map<SimpleTouristSiteResponseModel>(result);

            return this.Json(mappedResult);
        }
    }
}