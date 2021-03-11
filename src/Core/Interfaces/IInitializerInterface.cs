using System;
using System.Threading.Tasks;

namespace EnduranceContestManager.Core.Interfaces
{
    public interface IInitializerInterface
    {
        Task Run(IServiceProvider serviceProvider);
    }
}
