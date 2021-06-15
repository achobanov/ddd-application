using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using MediatR;
using Prism.Events;
using Prism.Regions;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class PrincipalUpdateFormBase<TGet, TGetModel, TUpdate> : PrincipalFormBase<TUpdate>,
        IMapFrom<TGetModel>,
        IMapTo<TUpdate>
        where TGet : IdentifiableRequest<TGetModel>, new()
        where TUpdate : IRequest
    {
        protected PrincipalUpdateFormBase(IApplicationService application, INavigationService navigation)
            : base(application, navigation)
        {
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var id = navigationContext.GetId();

            return this.Id == id;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var id = navigationContext.GetId();
            if (!id.HasValue)
            {
                throw new InvalidOperationException("Update form requires ID parameter.");
            }

            if (this.Id == default)
            {
                this.Load(id.Value);
            }
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
