using System;
using System.Threading.Tasks;

namespace Blog.Gateways.Web.Contracts
{
    public interface IInitializtion
    {
        Task Initialize(IServiceProvider serviceProvider);
    }
}
