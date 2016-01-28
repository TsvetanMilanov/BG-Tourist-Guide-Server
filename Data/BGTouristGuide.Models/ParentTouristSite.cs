namespace BGTouristGuide.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class ParentTouristSite
    {
        private ICollection<TouristSite> subtouristSites;

        public ParentTouristSite()
        {
            this.subtouristSites = new HashSet<TouristSite>();
        }

        public int Id { get; set; }

        [MinLength(DatabaseConstants.MinParentTouristSiteNameLength)]
        [MaxLength(DatabaseConstants.MaxParentTouristSiteNameLength)]
        [Required]
        public string Name { get; set; }

        [MaxLength(DatabaseConstants.MaxParentTouristSiteDescriptionLength)]
        public string Description { get; set; }

        public virtual ICollection<TouristSite> SubTouristSites
        {
            get { return this.subtouristSites; }
            set { this.subtouristSites = value; }
        }

        public ParentTouristSiteType Type { get; set; }

        public ParentTouristSiteStatus Status { get; set; }
    }
}
