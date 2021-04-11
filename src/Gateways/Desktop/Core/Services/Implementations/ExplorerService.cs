using Microsoft.WindowsAPICodePack.Dialogs;

namespace EnduranceJudge.Gateways.Desktop.Core.Services.Implementations
{
    public class ExplorerService : IExplorerService
    {
        public string SelectDirectory()
        {
            using var openFolderDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            if (openFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return openFolderDialog.FileName;
            }

            return null;
        }
    }
}
