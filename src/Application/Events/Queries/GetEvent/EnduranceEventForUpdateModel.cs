using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using System.Collections.Generic;

namespace EnduranceJudge.Application.Events.Queries.GetEvent
{
    public class EnduranceEventForUpdateModel : IEnduranceEventState
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string PopulatedPlace { get; private set; }
        public string CountryIsoCode { get; private set; }
        public IEnumerable<CompetitionDependantModel> Competitions { get; set; }
        public IEnumerable<PersonnelDependantModel> Personnel { get; set; }
    }
}
