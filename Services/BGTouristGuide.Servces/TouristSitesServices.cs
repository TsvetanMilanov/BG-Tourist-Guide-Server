namespace BGTouristGuide.Services
{
    using System.Linq;

    using Common.Constants;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class TouristSitesServices : ITouristSitesServices
    {
        IGenericRepository<ParentTouristSite> parentTouristSites;
        IGenericRepository<TouristSite> touristSites;

        public TouristSitesServices(
            IGenericRepository<ParentTouristSite> parentTouristSites,
            IGenericRepository<TouristSite> touristSites)
        {
            this.parentTouristSites = parentTouristSites;
            this.touristSites = touristSites;
        }

        public IQueryable<ParentTouristSite> GetAll()
        {
            return this.parentTouristSites.All();
        }

        public ParentTouristSite GetParentTouristSiteById(int id)
        {
            ParentTouristSite result = this.parentTouristSites.All()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return result;
        }

        public IQueryable<TouristSite> GetByTitleAndDescriptionSearch(string pattern)
        {
            pattern = pattern.ToLower();

            var result = this.parentTouristSites.All()
                .Where(p => (p.Name.ToLower().Contains(pattern) ||
                                p.Description.ToLower().Contains(pattern)) ||
                    (p.SubTouristSites.Any(t => t.Name.ToLower().Contains(pattern) ||
                                t.Description.ToLower().Contains(pattern))))
                .SelectMany(p => p.SubTouristSites.Where(t => t.Name.ToLower().Contains(pattern) ||
                    t.Description.ToLower().Contains(pattern)));

            return result;
        }

        public IQueryable<TouristSite> GetVisitedTouristSitesForUser(string userId)
        {
            var result = this.touristSites.All()
                   .Where(t => t.Visitors.Any(v => v.Id == userId));

            return result;
        }

        public TouristSite GetTouristSiteById(int id)
        {
            var result = this.touristSites.All()
                .Where(t => t.Id == id)
                .FirstOrDefault();

            return result;
        }

        public IQueryable<TouristSite> GetByParentTouristSiteId(int id)
        {
            var result = this.touristSites.All()
                .Where(t => t.ParentTouristSiteId == id);

            return result;
        }

        public IQueryable<string> GetParentTouristSitesNames(int page = 0)
        {
            var result = this.parentTouristSites.All()
                 .OrderBy(p => p.Name)
                 .Skip(page * GlobalConstants.PageSize)
                 .Take(GlobalConstants.PageSize)
                 .Select(p => p.Name);

            return result;
        }
    }
}
