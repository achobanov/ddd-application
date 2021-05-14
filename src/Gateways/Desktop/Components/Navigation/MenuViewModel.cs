using EnduranceJudge.Gateways.Desktop.Components.Content.Event.EnduranceEvents;
using EnduranceJudge.Gateways.Desktop.Components.Content.Event.EnduranceEvents.List;
using EnduranceJudge.Gateways.Desktop.Components.Content.Import;
using EnduranceJudge.Gateways.Desktop.Components.Content.PrintExample;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Events;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop.Components.Navigation
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly IEventAggregator eventAggregator;

        public MenuViewModel(
            INavigationService navigation,
            IApplicationService application,
            IEventAggregator eventAggregator) : base(application)
        {
            this.eventAggregator = eventAggregator;
            this.NavigateToImport = new DelegateCommand(navigation.NavigateToImport);
            this.NavigateToEvent = new DelegateCommand(navigation.NavigateToEvent);

            this.NavigateToPrintExample = new DelegateCommand(() => navigation.ChangeTo<PrintExample>(Regions.Content));
            this.NavigateToUpdateEvent = new DelegateCommand(() => navigation.ChangeTo<EnduranceEvent>(Regions.Content, 1));
            this.NavigateToPrintExample = new DelegateCommand(() => navigation.ChangeTo<PrintExample>(Regions.Content));
            this.NavigateToEventList = new DelegateCommand(() => navigation.ChangeTo<EnduranceEventList>(Regions.Content));
            this.CloseNotification = new DelegateCommand(this.CloseNotificationAction);

            this.Subscribe();
        }

        public DelegateCommand NavigateToImport { get; }
        public DelegateCommand NavigateToEvent { get; }
        public DelegateCommand NavigateToPrintExample { get; }
        public DelegateCommand CloseNotification { get; }
        public DelegateCommand NavigateToUpdateEvent { get; }
        public DelegateCommand NavigateToEventList { get; }

        private Visibility notificationVisibility = Visibility.Hidden;
        public Visibility NotificationVisibility
        {
            get => this.notificationVisibility;
            private set => this.SetProperty(ref this.notificationVisibility, value);
        }

        private string notificationMessage;
        public string NotificationMessage
        {
            get => this.notificationMessage;
            private set => this.SetProperty(ref this.notificationMessage, value);
        }

        private void CloseNotificationAction()
        {
            this.NotificationMessage = null;
            this.NotificationVisibility = Visibility.Hidden;
        }

        private void Subscribe()
        {
            this.eventAggregator
                .GetEvent<ValidationErrorEvent>()
                .Subscribe(this.SubscribeToValidationErrors);
        }

        private void SubscribeToValidationErrors(string message)
        {
            this.NotificationMessage = message;
            this.NotificationVisibility = Visibility.Visible;
        }
    }
}
