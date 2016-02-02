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

        ParentTouristSite GetParentTouristSiteById(int id);

        TouristSite GetTouristSiteById(int id);
    }
}
