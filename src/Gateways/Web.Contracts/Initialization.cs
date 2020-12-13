using System;
using System.Threading.Tasks;

namespace Blog.Gateways.Web.Contracts
{
    public interface IInitialization
    {
        Task Initialize(IServiceProvider serviceProvider);
    }
}
