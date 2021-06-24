﻿using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using EnduranceJudge.Gateways.Desktop.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using MediatR;
using Prism.Commands;
using Prism.Regions;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class RootFormBase<TCommand, TUpdateModel> : FormBase,
        IMapTo<TCommand>
        where TCommand : IRequest<TUpdateModel>
    {
        protected RootFormBase(IApplicationService application, INavigationService navigation) : base(navigation)
        {
            this.Application = application;

            this.Submit = new AsyncCommand(this.SubmitAction);
        }

        private bool IsCreateForm => this.Id == default;

        protected IApplicationService Application { get; }

        public DelegateCommand Submit { get; }
        protected virtual async Task SubmitAction()
        {
            var command = this.Map<TCommand>();

            var result = await this.Application.Execute(command);

            this.MapFrom(result);
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            if (this.IsCreateForm)
            {
                return true;
            }

            var id = navigationContext.GetId();

            return this.Id == id;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var id = navigationContext.GetId();
            if (id.HasValue)
            {
                this.Load(id.Value);
            }
        }

        private async Task Load(int id)
        {
            if (this.Id != default)
            {
                return;
            }

            var command = this.LoadCommand(id);

            var enduranceEvent = await this.Application.Execute(command);

            this.MapFrom(enduranceEvent);
        }

        protected abstract IRequest<TUpdateModel> LoadCommand(int id);
    }
}
