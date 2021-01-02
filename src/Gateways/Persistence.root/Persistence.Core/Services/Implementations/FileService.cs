using System;
using System.IO;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Persistence.Core.Services.Implementations
{
    public class FileService : IFileService
    {
        private static readonly string Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public async Task Create(string name, string content)
        {
            var path = this.BuildFilePath(name);

            await using var stream = new StreamWriter(path);
            await stream.WriteAsync(content);
        }

        public async Task<string> Read(string name)
        {
            var path = this.BuildFilePath(name);

            using var stream = new StreamReader(path);
            return await stream.ReadToEndAsync();
        }

        private string BuildFilePath(string fileName)
            => Path.Combine(Directory, fileName);
    }
}