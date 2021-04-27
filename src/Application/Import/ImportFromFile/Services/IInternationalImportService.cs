using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Import.Events;

namespace EnduranceJudge.Application.Import.ImportFromFile.Services
{
    public interface IInternationalImportService : IService
    {
        Event FromInternational(string filePath);
    }
}
