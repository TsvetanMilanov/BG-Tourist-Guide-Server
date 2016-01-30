namespace BGTouristGuide.Data.DataImporters
{
    using System;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Common.Constants;
    using Models;

    public class UsersDataImporter : DataImporter
    {
        public override void Import(BGTouristGuideDbContext db)
        {
            PasswordHasher hasher = new PasswordHasher();

            User admin = new User
            {
                Email = "admin@admin.com",
                UserName = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword("admin"),
                RegistrationDate = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            db.Users.Add(admin);

            IdentityUserRole adminRole = new IdentityUserRole();
            var dbadminRole = db.Roles.Where(r => r.Name == DatabaseConstants.AdminUserRole).FirstOrDefault();

            adminRole.UserId = admin.Id;
            adminRole.RoleId = dbadminRole.Id;

            dbadminRole.Users.Add(adminRole);

            db.SaveChanges();
        }
    }
}
