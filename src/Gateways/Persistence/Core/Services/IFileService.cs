using EnduranceJudge.Core.ConventionalServices;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Persistence.Core.Services
{
    public interface IFileService : IService
    {
        public Task Create(string name, string content);

        public Task<string> Read(string name);
    }
}
