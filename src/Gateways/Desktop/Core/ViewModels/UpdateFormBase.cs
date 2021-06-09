using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using EnduranceJudge.Gateways.Desktop.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using MediatR;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class UpdateFormBase<TGet, TGetModel, TUpdate> : ViewModelBase,
        IMapFrom<TGetModel>,
        IMapTo<TUpdate>
        where TGet : IIdentifiableRequest<TGetModel>, new()
        where TUpdate : IRequest
    {
        protected UpdateFormBase(IApplicationService application)
        {
            this.Application = application;
            this.Update = new AsyncCommand(this.UpdateAction);
        }

        protected IApplicationService Application { get; }

        public DelegateCommand Update { get; }
        protected virtual async Task UpdateAction()
        {
            var command = this.Map<TUpdate>();

            await this.Application.Execute(command);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var id = navigationContext.GetId();
            if (!id.HasValue)
            {
                throw new InvalidOperationException("Update form requires ID parameter.");
            }

            this.Load(id.Value);
        }

        private async Task Load(int id)
        {
            var command = new TGet
            {
                Id = id
            };

            var enduranceEvent = await this.Application.Execute(command);

            this.MapFrom(enduranceEvent);
        }
    }
}
