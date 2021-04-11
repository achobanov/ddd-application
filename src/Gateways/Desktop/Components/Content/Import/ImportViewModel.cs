using EnduranceJudge.Application.Import.ImportFromFile;
using EnduranceJudge.Application.Import.WorkFile;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using MediatR;
using Prism.Commands;
using System.Threading.Tasks;
using System.Windows;

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
            this.OpenImportFileDialog = new AsyncCommand(this.OpenImportFileDialogAction);
        }

        private string directoryPath;
        public string DirectoryPath
        {
            get => this.directoryPath;
            private set => this.SetProperty(ref this.directoryPath, value);
        }

        private Visibility importVisibility = Visibility.Hidden;
        public Visibility ImportVisibility
        {
            get => this.importVisibility;
            set => this.SetProperty(ref this.importVisibility, value);
        }
        private string importFilePath;
        public string ImportFilePath
        {
            get => this.importFilePath;
            set => this.SetProperty(ref this.importFilePath, value);
        }

        public DelegateCommand OpenFolderDialog { get; }
        public DelegateCommand OpenImportFileDialog { get; }

        private async Task OpenFolderDialogAction()
        {
            var selectedPath = this.explorer.SelectDirectory();
            if (selectedPath == null)
            {
                return;
            }

            this.DirectoryPath = selectedPath;

            var selectWorkFileRequest = new SelectWorkFile
            {
                DirectoryPath = selectedPath,
            };

            var isNewFileCreated = await this.mediator.Send(selectWorkFileRequest);
            if (isNewFileCreated)
            {
                this.ImportVisibility = Visibility.Visible;
            }
        }

        private async Task OpenImportFileDialogAction()
        {
            var path = this.explorer.SelectFile();
            if (path == null)
            {
                return;
            }

            this.ImportFilePath = path;

            var importFromFileRequest = new ImportFromFile
            {
                FilePath = path,
            };

            await this.mediator.Send(importFromFileRequest);
        }
    }
}
