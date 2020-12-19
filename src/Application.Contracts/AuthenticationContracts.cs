using EnduranceContestManager.Common.ConventionalServices;

namespace EnduranceContestManager.Application.Contracts
{
    public interface IAuthenticationContext : IScopedService
    {
        string Username { get; }
    }
}
