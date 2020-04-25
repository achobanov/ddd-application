namespace Blog.Application.Contracts
{
    using Blog.Application.Infrastructure.Services;

    public interface IAuthenticationContext : IScopedService
    {
        string Username { get; }
    }
}
