namespace Blog.Application.Contracts
{
    using Blog.Common.ConventionalServices;

    public interface IAuthenticationContext : IScopedService
    {
        string Username { get; }
    }
}
