namespace Blog.Application.Contracts
{
    using Blog.Common.ConventionalServices;

    public interface IAuthenticationContract : IScopedService
    {
        string Username { get; }
    }
}
