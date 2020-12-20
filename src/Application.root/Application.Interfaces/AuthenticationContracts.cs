using EnduranceContestManager.Common.ConventionalServices;

namespace EnduranceContestManager.Application.Interfaces
{
    public interface IAuthenticationContext : IScopedService
    {
        string Username { get; }
    }
}
