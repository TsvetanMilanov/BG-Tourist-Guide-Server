namespace BGTouristGuide.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BGTouristGuide.Common.Constants;

    public class Rating
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [Range(DatabaseConstants.MinRatingValue, DatabaseConstants.MaxRatingValue)]
        public int Value { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int TouristSiteId { get; set; }

        public TouristSite TouristSite { get; set; }
    }
}