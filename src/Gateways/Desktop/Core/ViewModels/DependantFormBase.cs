using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using Prism.Regions;
using System;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class DependantFormBase : FormBase
    {
        private Action<object> submitAction;

        protected DependantFormBase(IApplicationService application)
        {
            this.Application = application;
        }

        protected IApplicationService Application { get; }

        protected override void NavigateBackAction()
        {
            this.submitAction(this);
            base.NavigateBackAction();
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
                this.MapFrom(data);
            }

            this.submitAction = navigationContext.GetSubmitAction();
        }
    }
}
