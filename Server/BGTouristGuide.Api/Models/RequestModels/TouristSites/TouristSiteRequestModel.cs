namespace BGTouristGuide.Api.Models.RequestModels.TouristSites
{
    using System.ComponentModel.DataAnnotations;

    public class TouristSiteRequestModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int ParentTouristSiteId { get; set; }
    }
}