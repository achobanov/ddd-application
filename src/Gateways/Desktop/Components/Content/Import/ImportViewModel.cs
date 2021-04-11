using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using Prism.Commands;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Import
{
    public class ImportViewModel : ViewModelBase
    {
        private readonly IExplorerService explorer;

        public ImportViewModel(IExplorerService explorer)
        {
            this.explorer = explorer;
            this.OpenFolderDialog = new DelegateCommand(this.OpenFolderDialogAction);
        }

        private string folderPath;
        public string FolderPath
        {
            get => this.folderPath;
            private set => this.SetProperty(ref this.folderPath, value);
        }

        public DelegateCommand OpenFolderDialog { get; }

        private void OpenFolderDialogAction()
        {
            var selectedPath = this.explorer.SelectFolder();
            if (selectedPath != null)
            {
                this.FolderPath = selectedPath;
            }
        }
    }
}
