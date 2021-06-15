using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Events;
using EnduranceJudge.Gateways.Desktop.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using Prism.Events;
using Prism.Regions;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class DependantFormBase<TViewModel> : FormBase, IMapFrom<TViewModel>
        where TViewModel : DependantFormBase<TViewModel>
    {
        private readonly Type thisType;
        private readonly Type formCreateEventTye = typeof(DependantFormSubmitEvent<>);
        private readonly Type eventAggregatorType;
        private readonly IEventAggregator eventAggregator;

        private bool isUpdateMode;
        private Action<TViewModel> submitAction;

        protected DependantFormBase(IApplicationService application, IEventAggregator eventAggregator)
        {
            this.thisType = this.GetType();

            this.eventAggregator = eventAggregator;
            this.eventAggregatorType = eventAggregator?.GetType();
            this.Application = application;
        }

        protected IApplicationService Application { get; }

        protected override Task SubmitAction()
        {
            if (this is not TViewModel viewModel)
            {
                throw new Exception("kur");
            }

            this.submitAction(viewModel);

            this.Journal.GoBack();

            return Task.CompletedTask;
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var data = navigationContext.GetData();
            if (data != null)
            {
                return this.Equals(data);
            }

            return false;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var data = navigationContext.GetData();
            if (data != null)
            {
                this.isUpdateMode = true;
                this.MapFrom(data);
            }

            this.submitAction = navigationContext.GetAction<TViewModel>();
        }

        private void PublishCreatedEvent()
        {
            var eventType = this.formCreateEventTye.MakeGenericType(this.thisType);
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
