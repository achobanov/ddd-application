namespace Blog.Application.Infrastructure.Interfaces
{
    using System.Threading.Tasks;
    using Blog.Common.ConventionalServices;
    using Blog.Common.Models;

    public interface IIdentity : IService
    {
        Task<string> GetUserName(string userId);

        Task<(Result Result, string UserId)> CreateUser(string userName, string password);

        Task<Result> DeleteUser(string userId);
    }
}
