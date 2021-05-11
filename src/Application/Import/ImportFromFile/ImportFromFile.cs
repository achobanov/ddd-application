using EnduranceJudge.Application.Core.Exceptions;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Import.Contracts;
using EnduranceJudge.Application.Import.ImportFromFile.Services;
using EnduranceJudge.Core.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static EnduranceJudge.Application.ApplicationConstants;
using static EnduranceJudge.Localization.Strings.Application;

namespace EnduranceJudge.Application.Import.ImportFromFile
{
    public class ImportFromFile : IRequest
    {
        public string FilePath { get; set; }

        public class ImportFromFileHandler : Handler<ImportFromFile>
        {
            private readonly IHorseCommands horseCommands;
            private readonly INationalImportService nationalImport;
            private readonly IInternationalImportService internationalImport;
            private readonly IEventCommands eventCommands;
            private readonly IFileService file;

            public ImportFromFileHandler(
                IHorseCommands horseCommands,
                INationalImportService nationalImport,
                IInternationalImportService internationalImport,
                IEventCommands eventCommands,
                IFileService file)
            {
                this.horseCommands = horseCommands;
                this.nationalImport = nationalImport;
                this.internationalImport = internationalImport;
                this.eventCommands = eventCommands;
                this.file = file;
            }

            protected override async Task Handle(ImportFromFile request, CancellationToken cancellationToken)
            {
                var filePath = request.FilePath;
                var fileExtension = this.file.GetExtension(filePath);
                if (fileExtension != FileExtensions.Xml && fileExtension != FileExtensions.SupportedExcel)
                {
                    var message = string.Format(
                        UnsupportedImportFileTemplate,
                        FileExtensions.Xml,
                        FileExtensions.SupportedExcel);

                    throw new AppException(message);
                }

                if (fileExtension == FileExtensions.Xml)
                {
                    var enduranceEvent = this.internationalImport.FromInternational(filePath);
                    await this.eventCommands.Save(enduranceEvent, cancellationToken);
                }
                else
                {
                    var horses = this.nationalImport.ImportForNational(filePath);
                    await this.horseCommands.Create(horses, cancellationToken);
                }
            }
        }
    }
}
