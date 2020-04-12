namespace Blog.Application.Contracts
{
    using Blog.Application.Common.Services;

    public interface IAuthenticationContext : IScopedService
    {
        string UserId { get; }
    }
}
