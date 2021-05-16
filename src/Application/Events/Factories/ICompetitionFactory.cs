using EnduranceJudge.Domain.Aggregates.Event.Competitions;

namespace EnduranceJudge.Application.Events.Factories
{
    public interface ICompetitionFactory
    {
        Competition Create(ICompetitionState state);
    }
}
