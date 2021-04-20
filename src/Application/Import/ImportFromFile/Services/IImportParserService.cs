using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Import.Events;

namespace EnduranceJudge.Application.Import.ImportFromFile.Services
{
    public interface IImportParsesService : IService
    {
        Event FromInternational(string filePath);
    }
}
