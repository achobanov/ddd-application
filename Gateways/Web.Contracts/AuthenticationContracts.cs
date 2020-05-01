using System.Threading.Tasks;
using Blog.Common.Models;

namespace Blog.Gateways.Web.Contracts
{
    public interface IAuthenticationContract
    {
        Task<Result<string>> Login(ILoginContext model);

        Task Logout();

        Task<Result> Register(IRegisterContext model);
    }

    public interface IRegisterContext
    {
        string Username { get; }

        string Password { get; }
    }

    public interface ILoginContext
    {
        string Username { get; }

        string Password { get; }

        bool RememberMe { get; }
    }
}
