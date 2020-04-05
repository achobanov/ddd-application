namespace Blog.Application.Contracts
{
    using Blog.Application.Common.Services;

    public interface ICurrentUser : IScopedService
    {
        string UserId { get; }
    }
}
