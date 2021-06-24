using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Personnel
{
    public class PersonnelViewModel : DependantFormBase, IMap<PersonnelDependantModel>
    {
        private PersonnelViewModel() : base(null)
        {
            this.LoadRoles();
        }

        public PersonnelViewModel(IApplicationService application) : base(application)
        {
            this.LoadRoles();
        }

        public ObservableCollection<ComboBoxItemViewModel> RoleItems { get; private set; }

        private string name;
        public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }

        private int role;
        public int Role
        {
            get => this.role;
            set => this.SetProperty(ref this.role, value);
        }

        private void LoadRoles()
        {
            var roles = ComboBoxItemViewModel.FromEnum<PersonnelRole>();
            this.RoleItems = new ObservableCollection<ComboBoxItemViewModel>(roles);
        }
    }
}
