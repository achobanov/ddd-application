using AutoMapper;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Converters;

namespace EnduranceJudge.Gateways.Persistence.Entities.EnduranceEvents
{
    public class EnduranceEventEntityMaps : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            this.AddFromMaps(profile);
            this.AddToMaps(profile);
        }

        private void AddFromMaps(IProfileExpression profile)
        {
            profile.CreateMap<EnduranceEvent, EnduranceEventEntity>()
                .ForMember(d => d.Country, opt => opt.Ignore());
        }

        private void AddToMaps(IProfileExpression profile)
        {
        }
    }
}
