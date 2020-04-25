using Blog.Common.ConventionalServices;

namespace Blog.Application.Contracts
{
    public interface IAuthenticationContract : IScopedService
    {
        string Username { get; }
    }
}
