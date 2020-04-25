using System.Threading.Tasks;
using Blog.Common.Models;

namespace Blog.Gateways.Web.Contracts
{
    public interface IAuthenticationService
    {
        Task<Result<string>> Login(ILoginModelContract model);

        Task Logout();
        
        Task<Result> Register(IRegisterModelContract model);
    }
}
