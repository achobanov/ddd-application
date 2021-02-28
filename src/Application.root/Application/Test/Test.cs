using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Aggregates.Contest.Contests;
using EnduranceContestManager.Domain.Aggregates.Contest.Trials;
using EnduranceContestManager.Domain.Aggregates.Manager.Participants;
using EnduranceContestManager.Domain.Aggregates.Manager.DTOs;
using EnduranceContestManager.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Test
{
    public class Test : IRequest, IMapTo<Contest>
    {
        public string Name { get; set; }

        public class TestHandler : Handler<Test>
        {
            public TestHandler()
            {
            }

            protected override async Task Handle(Test request, CancellationToken cancellationToken)
            {
                var contest = new Contest(0, "Name", "place");

                var trial1 = new Trial(0, CompetitionType.International);
                var trial2 = new Trial(1, CompetitionType.National);
                var trialSame = new Trial(1, CompetitionType.National);

                contest.Add(trial1);
                contest.Add(trial2);

                contest.Remove(trial1);
                contest.Add(trialSame);
            }
        }
    }
}
