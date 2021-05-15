using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using Prism.Commands;

namespace EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem
{
    public class ListItemViewModel : ComboBoxItemViewModel
    {
        public ListItemViewModel(int id, string name, DelegateCommandBase command) : base(id, name)
        {
            this.Command = command;
        }

        public DelegateCommandBase Command { get; }
    }
}
