namespace BGTouristGuide.Services
{
    using System.Linq;

    using Contracts;
    using Data.Repositories;
    using Models;

    public class ScoreboardServices : IScoreboardServices
    {
        IGenericRepository<User> users;

        public ScoreboardServices(IGenericRepository<User> users)
        {
            this.users = users;
        }
        
        public IQueryable<User> GetUsersScoreboard()
        {
            var result = this.users.All()
                .OrderByDescending(u => u.Ratings.Sum(r => r.Value));

            return result;
        }
    }
}
