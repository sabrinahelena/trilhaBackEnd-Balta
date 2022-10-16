using BlogFundamentosAspNet.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BlogFundamentosAspNet.Extensions
{
    public static class RoleClaimsExtensions
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var result = new List<Claim>
            {
                new(ClaimTypes.Name, user.Email),
            };

            result.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Slug)));
            return result;
        }
    }
}
