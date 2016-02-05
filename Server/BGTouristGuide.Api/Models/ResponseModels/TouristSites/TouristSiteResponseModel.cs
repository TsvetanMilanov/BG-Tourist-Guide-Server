namespace BGTouristGuide.Api.Models.ResponseModels.TouristSites
{
    using BGTouristGuide.Models;

    public class TouristSiteResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }

        public double Rating { get; set; }
    }
}