using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Services;
using Prism.Commands;
using Prism.Regions;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Participants
{
    public class ParticipantViewModel : DependantFormBase, IMap<ParticipantDependantModel>
    {
        private ParticipantViewModel() : base(null, null)
        {
        }

        public ParticipantViewModel(IApplicationService application, INavigationService navigation)
            : base(application, navigation)
        {
            this.ToggleIsAverageSpeedInKmPhVisibility = new DelegateCommand(
                this.ToggleIsAverageSpeedInKmPhVisibilityAction);
        }

        private string rfId;
        public string RfId
        {
            get => this.rfId;
            set => this.SetProperty(ref this.rfId, value);
        }

        public int number;
        public int Number
        {
            get => this.number;
            set => this.SetProperty(ref this.number, value);
        }

        public int? maxAverageSpeedInKmPh;
        public int? MaxAverageSpeedInKmPh
        {
            get => this.maxAverageSpeedInKmPh;
            set => this.SetProperty(ref this.maxAverageSpeedInKmPh, value);
        }

        protected override ListItemViewModel ToListItem(DelegateCommand command)
        {
            var listItem = new ListItemViewModel(this.Id, this.Number.ToString(), command);
            return listItem;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            if (this.MaxAverageSpeedInKmPh.HasValue)
            {
                this.ShowMaxAverageSpeedInKmPh();
            }
        }

        public DelegateCommand ToggleIsAverageSpeedInKmPhVisibility { get; }
        public void ToggleIsAverageSpeedInKmPhVisibilityAction()
        {
            if (this.MaxAverageSpeedInKmPhVisibility == Visibility.Hidden)
            {
                this.ShowMaxAverageSpeedInKmPh();
            }
            else
            {
                this.HideMaxAverageSpeedInKmPh();
            }
        }
        private void ShowMaxAverageSpeedInKmPh()
        {
            this.MaxAverageSpeedInKmPhVisibility = Visibility.Visible;
        }
        private void HideMaxAverageSpeedInKmPh()
        {
            this.MaxAverageSpeedInKmPhVisibility = Visibility.Hidden;
            this.MaxAverageSpeedInKmPh = default;
        }

        private Visibility maxAverageSpeedInKmPhPhVisibility = Visibility.Hidden;
        public Visibility MaxAverageSpeedInKmPhVisibility
        {
            get => this.maxAverageSpeedInKmPhPhVisibility;
            set => this.SetProperty(ref this.maxAverageSpeedInKmPhPhVisibility, value);
        }
    }
}
