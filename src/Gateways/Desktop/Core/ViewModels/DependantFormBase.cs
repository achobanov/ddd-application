using EnduranceJudge.Gateways.Desktop.Core.Events;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using Prism.Commands;
using Prism.Events;
using System;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class DependantFormBase : ViewModelBase
    {
        private readonly Type formCreateEventTye = typeof(FormCreateEvent<>);

        private readonly Type eventAggregatorType;
        private readonly IEventAggregator eventAggregator;

        protected DependantFormBase()
        {
        }

        protected DependantFormBase(IApplicationService application, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregatorType = eventAggregator.GetType();
            this.Application = application;

            this.Save = new DelegateCommand(this.SaveAction);
        }

        protected IApplicationService Application { get; }

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

            this.Journal.GoBack();
        }
    }
}
