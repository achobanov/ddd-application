using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Import.Contracts;
using EnduranceJudge.Application.Import.ImportFromFile.Services;
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
            private readonly IImportParsesService importParses;
            private readonly IEventCommands commands;

            public ImportFromFileHandler(IImportParsesService importParses, IEventCommands commands)
            {
                this.importParses = importParses;
                this.commands = commands;
            }

            protected override async Task Handle(ImportFromFile request, CancellationToken cancellationToken)
            {
                var _event = this.importParses.FromInternational(request.FilePath);
                await this.commands.Save(_event, cancellationToken);
            }
        }
    }
}
