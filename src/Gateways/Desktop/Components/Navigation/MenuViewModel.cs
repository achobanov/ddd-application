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
            this.NavigateToImport = new DelegateCommand(navigation.NavigateTo<Import>);
            this.NavigateToPrintExample = new DelegateCommand(navigation.NavigateTo<PrintExample>);
            this.NavigateToCreateEvent = new DelegateCommand(navigation.NavigateTo<EnduranceEvent>);
            this.NavigateToUpdateEvent = new DelegateCommand(() => navigation.NavigateTo<EnduranceEvent>(1));
            this.NavigateToPrintExample = new DelegateCommand(navigation.NavigateTo<PrintExample>);
            this.NavigateToEventList = new DelegateCommand(navigation.NavigateTo<EnduranceEventList>);
            this.CloseNotification = new DelegateCommand(this.CloseNotificationAction);

            this.Subscribe();
        }

        public DelegateCommand NavigateToImport { get; }
        public DelegateCommand NavigateToPrintExample { get; }
        public DelegateCommand CloseNotification { get; }
        public DelegateCommand NavigateToCreateEvent { get; }
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
