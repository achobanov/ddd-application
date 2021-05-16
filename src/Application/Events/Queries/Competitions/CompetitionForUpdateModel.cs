using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Application.Events.Queries.Competitions
{
    public class CompetitionForUpdateModel : ICompetitionState
    {
        public int Id { get; set; }
        public CompetitionType Type { get; set; }
    }
}
