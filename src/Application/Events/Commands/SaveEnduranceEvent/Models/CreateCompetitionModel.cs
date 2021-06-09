using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Application.Events.Commands.SaveEnduranceEvent.Models
{
    public class CreateCompetitionModel : ICompetitionState
    {
        public int Id { get; set; }

        public CompetitionType Type { get; set; }
    }
}
