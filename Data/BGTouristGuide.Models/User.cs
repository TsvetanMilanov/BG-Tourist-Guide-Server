namespace BGTouristGuide.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Common.Constants;
    using System.ComponentModel.DataAnnotations.Schema;
    public class User : IdentityUser
    {
        private ICollection<Badge> badges;
        private ICollection<TouristSite> visitedTouristSites;
        private ICollection<Comment> comments;
        private ICollection<Rating> ratings;

        public User()
        {
            this.badges = new HashSet<Badge>();
            this.visitedTouristSites = new HashSet<TouristSite>();
            this.comments = new HashSet<Comment>();
            this.ratings = new HashSet<Rating>();
        }

        [MinLength(DatabaseConstants.MinFirstNameLength)]
        [MaxLength(DatabaseConstants.MaxFirstNameLength)]
        public string FirstName { get; set; }

        [MinLength(DatabaseConstants.MinLastNameLength)]
        [MaxLength(DatabaseConstants.MaxLastNameLength)]
        public string LastName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Badge> Badges
        {
            get { return this.badges; }
            set { this.badges = value; }
        }

        public virtual ICollection<TouristSite> VisitedTouristSites
        {
            get { return this.visitedTouristSites; }
            set { this.visitedTouristSites = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }

        [NotMapped]
        public int CalculatedRating { get; set; }
    }
}
