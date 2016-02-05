namespace BGTouristGuide.Services
{
    using System;
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

        public IQueryable<ParentTouristSite> GetParentTouristSites(int page = 0, int type = 0)
        {
            if (page < 0)
            {
                page = 0;
            }

            var result = this.parentTouristSites.All()
                 .Where(p => (int)p.Type == type)
                 .OrderBy(p => p.Name)
                 .Skip(page * GlobalConstants.PageSize)
                 .Take(GlobalConstants.PageSize);

            return result;
        }

        public IQueryable<TouristSite> GetTouristSitesNearMe(double latitude, double longitude, int page = 0)
        {
            // TODO: Add check for latitude and longitude.

            return this.touristSites.All()
                .OrderBy(t => t.Name)
                .Skip(page * GlobalConstants.PageSize)
                .Take(GlobalConstants.PageSize);
        }

        public ParentTouristSite AddParentTouristSite(string name, string description, ParentTouristSiteType type)
        {
            ParentTouristSite parentTouristSite = new ParentTouristSite
            {
                Name = name,
                Description = description,
                Type = type
            };

            this.parentTouristSites.Add(parentTouristSite);

            this.parentTouristSites.SaveChanges();

            return parentTouristSite;
        }
    }
}
