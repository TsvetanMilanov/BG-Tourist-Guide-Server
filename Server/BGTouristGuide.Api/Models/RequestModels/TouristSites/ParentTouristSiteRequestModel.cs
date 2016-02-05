namespace BGTouristGuide.Api.Models.RequestModels.TouristSites
{
    using System.ComponentModel.DataAnnotations;

    using BGTouristGuide.Models;

    public class ParentTouristSiteRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public ParentTouristSiteType Type { get; set; }
    }
}