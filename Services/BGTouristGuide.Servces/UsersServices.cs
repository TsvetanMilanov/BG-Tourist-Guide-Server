namespace BGTouristGuide.Services
{
    using Contracts;
    using Data.Repositories;
    using Models;

    public class UsersServices : IUsersServices
    {
        IGenericRepository<User> users;

        public UsersServices(IGenericRepository<User> users)
        {
            this.users = users;
        }

        public User GetProfileInfo(string userId)
        {
            var result = this.users.GetById(userId);

            return result;
        }
    }
}
