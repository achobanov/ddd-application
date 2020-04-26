using System.Threading.Tasks;
using Blog.Common.Mappings;
using Blog.Common.Models;

namespace Blog.Gateways.Web.Contracts
{
    public interface IAuthenticationContract
    {
        Task<Result<string>> Login(ILoginModel model);

        Task Logout();

        Task<Result> Register(IRegisterModel model);
    }

    public interface IRegisterModel
    {
        string Username { get; }

        string Password { get; }
    }

    public interface ILoginModel
    {
        string Username { get; }

        string Password { get; }

        bool RememberMe { get; }
    }
}
