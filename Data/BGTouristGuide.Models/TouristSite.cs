namespace BGTouristGuide.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class TouristSite
    {
        private ICollection<TouristSite> subTouristSites;
        private ICollection<Comment> comments;
        private ICollection<User> visitors;
        private ICollection<Rating> ratings;

        public TouristSite()
        {
            this.subTouristSites = new HashSet<TouristSite>();
            this.comments = new HashSet<Comment>();
            this.visitors = new HashSet<User>();
            this.ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [MinLength(DatabaseConstants.MinTouristSiteNameLength)]
        [MaxLength(DatabaseConstants.MaxTouristSiteNameLength)]
        [Required]
        public string Name { get; set; }

        [MinLength(DatabaseConstants.MinTouristSiteDescriptionLength)]
        [MaxLength(DatabaseConstants.MaxTouristSiteDescriptionLength)]
        [Required]
        public string Description { get; set; }

        public virtual ICollection<TouristSite> SubTouristSites
        {
            get { return this.subTouristSites; }
            set { this.subTouristSites = value; }
        }

        public TouristSiteStatus Status { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<User> Visitors
        {
            get { return this.visitors; }
            set { this.visitors = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public TouristSiteType Type { get; set; }

        [MinLength(DatabaseConstants.MinTouristSiteAddressLength)]
        [MaxLength(DatabaseConstants.MaxTouristSiteAddressLength)]
        [Required]
        public string Address { get; set; }
    }
}