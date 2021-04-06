using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Core.Interfaces
{
    public interface IInitializerInterface
    {
        int RunningOrder { get; }

        void Run(IServiceProvider serviceProvider);
    }
}
