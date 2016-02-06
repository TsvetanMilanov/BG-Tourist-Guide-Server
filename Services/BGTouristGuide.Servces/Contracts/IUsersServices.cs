namespace BGTouristGuide.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public interface IUsersServices
    {
        User GetProfileInfo(string userId);
    }
}
