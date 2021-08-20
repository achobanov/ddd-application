using System;
using System.Threading.Tasks;

namespace Blog.Gateways.Web.Contracts
{
    public interface IInitializer
    {
        Task Initialize(IServiceProvider serviceProvider);
    }
}
