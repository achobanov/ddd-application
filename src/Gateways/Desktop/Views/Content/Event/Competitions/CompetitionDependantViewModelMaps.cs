using AutoMapper;
using EnduranceJudge.Application.Events.Commands.EnduranceEvents;
using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions
{
    public class CompetitionDependantViewModelMaps : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            profile.CreateMap<CompetitionDependantViewModel, CompetitionDependantModel>()
                .MapMember(d => d.Type, s => (CompetitionType)s.Type);

            profile.CreateMap<CompetitionDependantModel, CompetitionDependantViewModel>()
                .MapMember(d => d.Type, s => (int)s.Type);
        }
    }
}
