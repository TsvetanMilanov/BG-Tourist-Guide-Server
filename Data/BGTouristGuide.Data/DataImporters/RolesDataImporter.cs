namespace BGTouristGuide.Data.DataImporters
{
    using Common.Constants;
    using Microsoft.AspNet.Identity.EntityFramework;
    public class RolesDataImporter : DataImporter
    {
        public override void Import(BGTouristGuideDbContext db)
        {
            var roles = new string[]
            {
                DatabaseConstants.AdminUserRole,
                DatabaseConstants.RegularUserRole
            };

            foreach (var role in roles)
            {
                var dbRole = new IdentityRole();
                dbRole.Name = role;
                db.Roles.Add(dbRole);
            }

            db.SaveChanges();
        }
    }
}
