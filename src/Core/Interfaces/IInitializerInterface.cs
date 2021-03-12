using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Core.Interfaces
{
    public interface IInitializerInterface
    {
        Task Run(IServiceProvider serviceProvider);
    }
}
