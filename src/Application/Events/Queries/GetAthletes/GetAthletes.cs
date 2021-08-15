using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Domain.Aggregates.Event.Participants;
using EnduranceJudge.Domain.Aggregates.Import.Athletes;
using MediatR;
using System.Collections.Generic;

namespace EnduranceJudge.Application.Events.Queries.GetAthletes
{
    public class GetAthletes : IRequest<IEnumerable<AthleteModel>>
    {
        public class GetAthletesHandler : GetAllHandler<GetAthletes, AthleteModel, Athlete>
        {
            public GetAthletesHandler(IQueriesBase<Athlete> queries) : base(queries)
            {
            }
        }
    }
}
