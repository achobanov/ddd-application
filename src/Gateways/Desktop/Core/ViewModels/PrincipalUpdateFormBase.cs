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
        where TGet : IIdentifiableRequest<TGetModel>, new()
        where TUpdate : IRequest
    {
        protected PrincipalUpdateFormBase(
            IApplicationService application,
            IEventAggregator eventAggregator,
            INavigationService navigation)
            : base(application, eventAggregator, navigation)
        {
        }

        private int id;
        public int Id
        {
            get => this.id;
            set => this.SetProperty(ref this.id, value);
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

        protected void ChangeTo<T>(int id)
            where T : IView
        {
            this.Navigation.ChangeTo<T>(id);
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
