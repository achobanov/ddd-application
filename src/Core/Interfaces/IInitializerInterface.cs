using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Core.Interfaces
{
    public interface IInitializerInterface
    {
        int Order { get; }

        Task Run(IServiceProvider serviceProvider);
    }
}
