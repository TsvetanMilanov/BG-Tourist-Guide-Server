namespace BGTouristGuide.Services.Contracts
{
    using System.Linq;

    using Models;

    public interface ITouristSitesServices
    {
        IQueryable<ParentTouristSite> GetAll();

        IQueryable<TouristSite> GetByTitleAndDescriptionSearch(string pattern);

        IQueryable<TouristSite> GetVisitedTouristSitesForUser(string userId);

        IQueryable<TouristSite> GetByParentTouristSiteId(int id);

        IQueryable<ParentTouristSite> GetParentTouristSites(int page = 0, int type = 0);

        IQueryable<TouristSite> GetTouristSitesNearMe(double latitude, double longitude, int page = 0);

        IQueryable<TouristSite> GetTouristSitesForRating(int page = 0);

        IQueryable<TouristSite> GetTouristSitesForApproving(int page = 0);

        ParentTouristSite GetParentTouristSiteById(int id);

        TouristSite GetTouristSiteById(int id);

        ParentTouristSite AddParentTouristSite(string name, string description, ParentTouristSiteType type);

        TouristSite AddTouristSite(
            string name,
            string description,
            string address,
            double latitude,
            double longitude,
            int parentTouristSiteId);

        void VisitTouristSite(string userId, int touristSiteId);

        void ChangeStatus(int id, TouristSiteStatus status);
    }
}
