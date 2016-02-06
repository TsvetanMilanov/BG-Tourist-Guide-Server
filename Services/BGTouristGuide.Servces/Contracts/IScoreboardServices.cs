namespace BGTouristGuide.Services.Contracts
{
    using System.Linq;

    using Models;

    public interface IScoreboardServices
    {
        IQueryable<User> GetUsersScoreboard();
    }
}
