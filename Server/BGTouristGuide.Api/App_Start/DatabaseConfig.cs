namespace BGTouristGuide.Api.App_Start
{
    using System.Data.Entity;

    using Data;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BGTouristGuideDbContext, Configuration>());
        }
    }
}