using Blog.Common.ConventionalServices;

namespace Blog.Application.Contracts
{
    public interface IAuthenticationContext : IScopedService
    {
        string Username { get; }
    }
}
