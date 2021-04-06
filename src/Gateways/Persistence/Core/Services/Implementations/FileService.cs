using System;
using System.IO;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Persistence.Core.Services.Implementations
{
    public class FileService : IFileService
    {
        private static readonly string Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public async Task Create(string name, string content)
        {
            var path = this.BuildFilePath(name);

            await using (var stream = new StreamWriter(path))
            {
                await stream.WriteAsync(content);
            }
        }

        public string Read(string name)
        {
            var path = this.BuildFilePath(name);

            if (!File.Exists(path))
            {
                return null;
            }

            using (var stream = new StreamReader(path))
            {
                return stream.ReadToEnd();
            }
        }

        private string BuildFilePath(string fileName)
            => Path.Combine(Directory, fileName);
    }
}
