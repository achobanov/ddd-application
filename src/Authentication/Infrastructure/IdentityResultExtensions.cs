using System.Linq;
using EnduranceContestManager.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace EnduranceContestManager.Authentication.Infrastructure
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
            => result.Succeeded
                ? Result.Success
                : Result.Failure(result.Errors.Select(e => e.Description).ToArray());
    }
}