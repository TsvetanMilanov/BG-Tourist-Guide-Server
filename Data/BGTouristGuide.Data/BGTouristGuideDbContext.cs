namespace BGTouristGuide.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class BGTouristGuideDbContext : IdentityDbContext<User>
    {
#if (DEBUG)
        public BGTouristGuideDbContext()
             : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
#else
        public BGTouristGuideDbContext()
            : base("ProductionConnection", throwIfV1Schema: false)
        {
        }
#endif

        public virtual IDbSet<TouristSite> TouristSites { get; set; }
        public virtual IDbSet<Badge> Badges { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
        public virtual IDbSet<Rating> Ratings { get; set; }
        public virtual IDbSet<QRImage> QRImages { get; set; }

        public static BGTouristGuideDbContext Create()
        {
            return new BGTouristGuideDbContext();
        }
    }
}
