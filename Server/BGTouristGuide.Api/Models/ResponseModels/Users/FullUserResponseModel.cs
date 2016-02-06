namespace BGTouristGuide.Api.Models.ResponseModels.Users
{
    using System;
    using System.Collections.Generic;

    using Common;
    using TouristSites;

    public class FullUserResponseModel
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<BadgeResponseModel> Badges { get; set; }

        public ICollection<TouristSiteResponseModel> VisitedTouristSites { get; set; }
    }
}