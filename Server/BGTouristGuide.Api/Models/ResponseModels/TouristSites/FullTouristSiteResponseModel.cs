namespace BGTouristGuide.Api.Models.ResponseModels.TouristSites
{
    using System.Collections.Generic;

    using BGTouristGuide.Models;

    public class FullTouristSiteResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ParentTouristSiteType Type { get; set; }

        public IEnumerable<TouristSiteResponseModel> SubTouristSites { get; set; }
    }
}