namespace BGTouristGuide.Api.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Newtonsoft.Json;

    using BGTouristGuide.Models;

    public static class IdentityUtilities
    {
        public static string CreateJsonFromOAuthIdentityRoles(ClaimsIdentity oAuthIdentity)
        {
            List<string> roles = oAuthIdentity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            string result = JsonConvert.SerializeObject(roles);

            return result;
        }

        public static async Task<IdentityResult> AddRoleToUser(User user, ApplicationUserManager manager, string authenticationType, string role)
        {
            var oAuthIdentity = await user.GenerateUserIdentityAsync(manager, authenticationType);

            Claim roleClaim = new Claim(ClaimTypes.Role, role);

            IdentityResult result = await manager.AddClaimAsync(user.Id, roleClaim);

            return result;
        }
    }
}