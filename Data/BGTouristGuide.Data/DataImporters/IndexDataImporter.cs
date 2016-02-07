namespace BGTouristGuide.Data.DataImporters
{
    using System.Linq;

    public class IndexDataImporter : DataImporter
    {
        public override void Import(BGTouristGuideDbContext db)
        {
            if (db.TouristSites.Any())
            {
                return;
            }

            RolesDataImporter rolesDataImporter = new RolesDataImporter();
            UsersDataImporter usersDataImporter = new UsersDataImporter();
            TouristSitesImporter touristSitesDataimporter = new TouristSitesImporter();

            rolesDataImporter.Import(db);
            usersDataImporter.Import(db);
            touristSitesDataimporter.Import(db);

            db.SaveChanges();
            db.Dispose();
        }
    }
}
