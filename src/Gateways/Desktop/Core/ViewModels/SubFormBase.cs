using EnduranceJudge.Gateways.Desktop.Core.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public class CreateFormBase : ViewModelBase
    {
        private readonly Type formCreateEventTye = typeof(FormCreateEvent<>);

        private readonly Type eventAggregatorType;
        private readonly IEventAggregator eventAggregator;

        public CreateFormBase(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregatorType = eventAggregator.GetType();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            this.SaveAction();
        }

        public DelegateCommand Save { get; }

        private void SaveAction()
        {
            var thisType = this.GetType();

            var eventType = this.formCreateEventTye.MakeGenericType(thisType);

            var getEventMethodName = nameof(this.eventAggregator.GetEvent);
            var getEventMethod = this.eventAggregatorType
                .GetMethod(getEventMethodName)
                !.MakeGenericMethod(eventType);

            var @event = getEventMethod.Invoke(this.eventAggregator, null);

            var publishMethod = eventType.GetMethod(DesktopConstants.PrismEventPublishMethodName);
            publishMethod!.Invoke(@event, new object[] { this });
        }
    }
}
