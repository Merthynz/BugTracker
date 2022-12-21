﻿using System.Security.Claims;
using System.Security.Principal;

#nullable disable

namespace BugTracker.Extensions
{
    public static class IdentityExtensions
    {
        public static int? GetCompanyId(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("CompanyId");
            // Ternary operator (if/else)
            return (claim != null) ? int.Parse(claim.Value) : null;
        }
    }
}