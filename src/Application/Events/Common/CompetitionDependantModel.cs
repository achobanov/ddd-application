using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Application.Events.Common
{
    public class CompetitionDependantModel : ICompetitionState
    {
        public int Id { get; set; }

        public CompetitionType Type { get; set; }
        public string Name { get; set; }
    }
}
