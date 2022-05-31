﻿using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarApi.Handler
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            //var scopes = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer).Value.Split(' ');
            var permissions = context.User.FindAll(p => p.Type == "permissions");

            var permissionsList = string.Join(',', permissions);
            if (permissionsList.Contains(requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
