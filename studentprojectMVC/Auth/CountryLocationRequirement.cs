using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace studentprojectMVC.Auth
{
    public class CountryLocationRequirement : AuthorizationHandler<CountryLocationRequirement>, IAuthorizationRequirement
    {
        private readonly string _countryLocationRequirement;

        public CountryLocationRequirement(string countryLocationRequirement)
        {
            _countryLocationRequirement = countryLocationRequirement;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CountryLocationRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Country))
            {
                return Task.CompletedTask;
            }

            var country = context.User.FindFirst(c => c.Type == ClaimTypes.Country).Value;

            if (country == "Belgium")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
