using System;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Desktop.Interfaces
{
    public interface IInitializerInterface
    {
        Task Run(IServiceProvider serviceProvider);
    }
}