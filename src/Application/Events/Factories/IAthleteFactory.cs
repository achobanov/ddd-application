using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Common.Athletes;
using EnduranceJudge.Domain.States;

namespace EnduranceJudge.Application.Events.Factories
{
    public interface IAthleteFactory : IService
    {
        Athlete Create(IAthleteState data);
    }
}
