namespace BGTouristGuide.Data.DataImporters
{
    public abstract class DataImporter
    {
        public abstract void Import(BGTouristGuideDbContext db);
    }
}
