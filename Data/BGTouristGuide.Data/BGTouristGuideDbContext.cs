namespace BGTouristGuide.Data
{
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

        public static BGTouristGuideDbContext Create()
        {
            return new BGTouristGuideDbContext();
        }
    }
}
