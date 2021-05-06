using EnduranceJudge.Gateways.Desktop.Components.Content.FirstPage;
using EnduranceJudge.Gateways.Desktop.Components.Content.Import;
using EnduranceJudge.Gateways.Desktop.Components.Content.PrintExample;
using EnduranceJudge.Gateways.Desktop.Components.Content.SecondPage;
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
            this.NavigateToFirst = new DelegateCommand(navigation.NavigateTo<First>);
            this.NavigateToSecond = new DelegateCommand(navigation.NavigateTo<Second>);
            this.NavigateToImport = new DelegateCommand(navigation.NavigateTo<Import>);
            this.NavigateToPrintExample = new DelegateCommand(navigation.NavigateTo<PrintExample>);
            this.CloseNotification = new DelegateCommand(this.CloseNotificationAction);

            this.Subscribe();
        }

        public DelegateCommand NavigateToFirst { get; }
        public DelegateCommand NavigateToSecond { get; }
        public DelegateCommand NavigateToImport { get; }
        public DelegateCommand NavigateToPrintExample { get; }
        public DelegateCommand CloseNotification { get; }


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
