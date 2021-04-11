using EnduranceJudge.Application.Import.WorkFile;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using MediatR;
using Prism.Commands;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Import
{
    public class ImportViewModel : ViewModelBase
    {
        private readonly IExplorerService explorer;
        private readonly IMediator mediator;

        public ImportViewModel(IExplorerService explorer, IMediator mediator)
        {
            this.explorer = explorer;
            this.mediator = mediator;
            this.OpenFolderDialog = new AsyncCommand(this.OpenFolderDialogAction);
        }

        private string folderPath;
        public string FolderPath
        {
            get => this.folderPath;
            private set => this.SetProperty(ref this.folderPath, value);
        }

        public DelegateCommand OpenFolderDialog { get; }

        private async Task OpenFolderDialogAction()
        {
            var selectedPath = this.explorer.SelectFolder();
            if (selectedPath != null)
            {
                this.FolderPath = selectedPath;
            }

            var selectWorkFileRequest = new SelectWorkFile
            {
                DirectoryPath = selectedPath,
            };

            var isNewFileCreated = await this.mediator.Send(selectWorkFileRequest);

        }
    }
}
