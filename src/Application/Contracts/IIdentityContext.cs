namespace Blog.Application.Contracts
{
    using Blog.Application.Common.Services;

    public interface IIdentityContext : IScopedService
    {
        string UserId { get; }
    }
}
