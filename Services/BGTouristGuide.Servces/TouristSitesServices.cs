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
        private IGenericRepository<ParentTouristSite> parentTouristSites;
        private IGenericRepository<TouristSite> touristSites;
        private IGenericRepository<User> users;

        public TouristSitesServices(
            IGenericRepository<ParentTouristSite> parentTouristSites,
            IGenericRepository<TouristSite> touristSites,
            IGenericRepository<User> users)
        {
            this.parentTouristSites = parentTouristSites;
            this.touristSites = touristSites;
            this.users = users;
        }

        public IQueryable<ParentTouristSite> GetAll()
        {
            return this.parentTouristSites.All();
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
                .Where(t => t.Status == TouristSiteStatus.ApprovedForVisiting)
                .OrderBy(t => t.Name)
                .Skip(page * GlobalConstants.PageSize)
                .Take(GlobalConstants.PageSize);
        }

        public ParentTouristSite GetParentTouristSiteById(int id)
        {
            ParentTouristSite result = this.parentTouristSites.All()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            var visibleResults = result.SubTouristSites
                .Where(t => t.Status == TouristSiteStatus.ApprovedForVisiting)
                .ToList();

            result.SubTouristSites = visibleResults;

            return result;
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

        public TouristSite AddTouristSite(
            string name,
            string description,
            string address,
            double latitude,
            double longitude,
            int parentTouristSiteId)
        {
            TouristSite touristSite = new TouristSite
            {
                Name = name,
                Description = description,
                Address = address,
                Latitude = latitude,
                Longitude = longitude,
                Status = TouristSiteStatus.WaitingForApproval,
                ParentTouristSiteId = parentTouristSiteId
            };

            this.touristSites.Add(touristSite);

            this.touristSites.SaveChanges();

            return touristSite;
        }

        public IQueryable<TouristSite> GetTouristSitesForRating(int page = 0)
        {
            var result = this.touristSites.All()
                .Where(t => t.Status == TouristSiteStatus.ApprovedForRating)
                .OrderBy(t => t.Name)
                .Skip(page * GlobalConstants.PageSize)
                .Take(GlobalConstants.PageSize);

            return result;
        }

        public IQueryable<TouristSite> GetTouristSitesForApproving(int page = 0)
        {
            var result = this.touristSites.All()
                .Where(t => t.Status == TouristSiteStatus.WaitingForApproval)
                .OrderBy(t => t.Name)
                .Skip(page * GlobalConstants.PageSize)
                .Take(GlobalConstants.PageSize);

            return result;
        }

        public void VisitTouristSite(string userId, int touristSiteId)
        {
            var touristSite = this.touristSites.GetById(touristSiteId);

            var user = this.users.GetById(userId);

            user.VisitedTouristSites.Add(touristSite);
            touristSite.Visitors.Add(user);

            foreach (var item in user.VisitedTouristSites)
            {
                if (item.ParentTouristSite.Type == ParentTouristSiteType.GovernemtDefined)
                {
                    user.CalculatedRating += GlobalConstants.OfficialTouristSiteAwardPoints;
                }
                else
                {
                    user.CalculatedRating += GlobalConstants.UnofficialTouristSiteAwardPoints;
                }
            }

            if (user.CalculatedRating >= GlobalConstants.SecondBadgePoints && user.CalculatedRating < GlobalConstants.ThirdBadgepoints)
            {
                user.Badges.Add(new Badge
                {
                    Title = BadgeTitle.Tourist
                });
            }
            else if (user.CalculatedRating >= GlobalConstants.ThirdBadgepoints)
            {
                user.Badges.Add(new Badge
                {
                    Title = BadgeTitle.OldTourist
                });
            }
            
            this.users.SaveChanges();
        }

        public void ChangeStatus(int id, TouristSiteStatus status)
        {
            var touristSite = this.touristSites.GetById(id);

            touristSite.Status = status;

            this.touristSites.SaveChanges();
        }

        public void Rate(int id, int rating, string userId)
        {
            var touristSite = this.touristSites.GetById(id);

            touristSite.Ratings.Add(new Rating
            {
                Value = rating,
                CreatedOn = DateTime.Now,
                UserId = userId
            });

            this.touristSites.SaveChanges();
        }
    }
}
