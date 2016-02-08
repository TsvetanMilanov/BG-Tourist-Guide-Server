namespace BGTouristGuide.Api.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using BGTouristGuide.Models;
    using Common.Constants;
    using Services.Contracts;

    [RoutePrefix("api/QrCodes")]
    public class QrCodesController : ApiController
    {
        private IQrCodeServices qrCodes;
        private ITouristSitesServices touristSites;

        public QrCodesController(IQrCodeServices qrCodes, ITouristSitesServices touristSites)
        {
            this.qrCodes = qrCodes;
            this.touristSites = touristSites;
        }

        [HttpGet]
        [Route("GenerateForAll")]
        public IHttpActionResult GenerateQrCodesForAllTouristSites()
        {
            var urls = this.touristSites.GetAll()
                .SelectMany(p => p.SubTouristSites)
                .Where(t => t.Status == TouristSiteStatus.ApprovedForVisiting)
                .ToList()
                .Select(t => string.Format("{0}/api/TouristSites/Visit?id={1}", GlobalConstants.ProductionApplicationUrl, t.Id));

            string appDataPath = HttpContext.Current.Server.MapPath("~/App_Data");

            this.qrCodes.GenerateQrCodesForIds(appDataPath, urls);

            return this.Ok();
        }
    }
}