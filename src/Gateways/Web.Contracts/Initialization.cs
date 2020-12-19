using System;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Web.Contracts
{
    public interface IInitializer
    {
        Task Initialize(IServiceProvider serviceProvider);
    }
}
