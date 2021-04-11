using System;
using System.IO;
using System.Threading.Tasks;

namespace EnduranceJudge.Core.Services.Implementations
{
    public class FileService : IFileService
    {
        public bool Exists(string path)
            => File.Exists(path);

        public async Task Create(string filePath, string content)
        {
            await using var stream = new StreamWriter(filePath);
            await stream.WriteAsync(content);
        }

        public string Read(string filePath)
        {
            if (!this.Exists(filePath))
            {
                throw new InvalidOperationException($"File '{filePath}' does not exist.");
            }

            using var stream = new StreamReader(filePath);
            return stream.ReadToEnd();
        }
    }
}
