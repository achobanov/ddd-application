using EnduranceJudge.Core.ConventionalServices;
using System.Threading.Tasks;

namespace EnduranceJudge.Core.Services
{
    public interface IFileService : IService
    {
        bool Exists(string path);

        public Task Create(string filePath, string content);

        public Task<string> Read(string name);
    }
}
