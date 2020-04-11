namespace Blog.Gateways.Web.Contracts
{
    using System.Threading.Tasks;
    using Blog.Application.Common.Models;
    using Blog.Application.Common.Services;
    using Microsoft.AspNetCore.Identity;

    // Work in progress - it is not yet used.
    public interface IAuthenticationService : IService
    {
        Task<Result> Login();

        Task<Result> Logout();

        Task<Result> Create(IdentityUser user);

        Task<Result> ChangePassword(IdentityUser user);

        Task<Result> Delete(IdentityUser user);

        Task<Result> Delete(string userId);
    }
}
