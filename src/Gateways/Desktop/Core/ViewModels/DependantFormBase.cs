using EnduranceJudge.Gateways.Desktop.Core.Events;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class DependantFormBase : FormBase
    {
        private readonly Type formCreateEventTye = typeof(DependantFormSubmitEvent<>);

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
        }

        protected IApplicationService Application { get; }

        protected override Task SubmitAction()
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

            return Task.CompletedTask;
        }
    }
}
