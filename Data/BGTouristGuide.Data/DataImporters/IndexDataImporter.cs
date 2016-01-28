namespace BGTouristGuide.Data.DataImporters
{
    public class IndexDataImporter : DataImporter
    {
        public override void Import(BGTouristGuideDbContext db)
        {
            var rolesDataImporter = new RolesDataImporter();

            rolesDataImporter.Import(db);

            db.SaveChanges();
            db.Dispose();
        }
    }
}
