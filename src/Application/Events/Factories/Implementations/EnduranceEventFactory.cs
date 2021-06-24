using EnduranceJudge.Application.Events.Commands.EnduranceEvents;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using System.Linq;

namespace EnduranceJudge.Application.Events.Factories.Implementations
{
    public class EnduranceEventFactory : IEnduranceEventFactory
    {
        private readonly ICompetitionFactory competitionFactory;
        private readonly IPersonnelFactory personnelFactory;

        public EnduranceEventFactory(ICompetitionFactory competitionFactory, IPersonnelFactory personnelFactory)
        {
            this.competitionFactory = competitionFactory;
            this.personnelFactory = personnelFactory;
        }

        public EnduranceEvent Create(SaveEnduranceEvent data)
        {
            var enduranceEvent = new EnduranceEvent(data);

            foreach (var competitionData in data.Competitions)
            {
                var competition = this.competitionFactory.Create(competitionData);
                enduranceEvent.Add(competition);
            }

            var personnel = data.Personnel.Select(this.personnelFactory.Create);
            personnel.ForEach(enduranceEvent.Add);

            return enduranceEvent;
        }
    }
}
