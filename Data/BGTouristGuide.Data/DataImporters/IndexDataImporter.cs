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

            var rolesDataImporter = new RolesDataImporter();
            var touristSitesDataimporter = new TouristSitesImporter();

            rolesDataImporter.Import(db);
            touristSitesDataimporter.Import(db);

            db.SaveChanges();
            db.Dispose();
        }
    }
}
