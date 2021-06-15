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
    }
}
