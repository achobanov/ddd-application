using EnduranceJudge.Application.Core.Handlers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Import.ImportFromFile
{
    public class ImportFromFile : IRequest
    {
        public string FilePath { get; set; }

        public class ImportFromFileHandler : Handler<ImportFromFile>
        {
            protected override Task Handle(ImportFromFile request, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
