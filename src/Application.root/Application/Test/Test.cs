using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Aggregates.Contest.Contests;
using EnduranceContestManager.Domain.Aggregates.Manager.Participant;
using EnduranceContestManager.Domain.Aggregates.Manager.DTOs;
using EnduranceContestManager.Domain.Enums;
using MediatR;
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
                // var trial60 = new TrialDto
                // {
                //     StartTime = DateTime.Now,
                //     Type = CompetitionType.National,
                //     Phases = new List<PhaseDto>
                //     {
                //         new PhaseDto
                //         {
                //             Category = Category.Kids,
                //             IsFinal = false,
                //             OrderBy = 1,
                //             LengthInKilometers = 20,
                //             RestTimeInMinutes = 15,
                //             MaxRecoveryTimeInMinutes = 15,
                //             MaxSpeedInKpH = 25,
                //         },
                //         new PhaseDto
                //         {
                //             Category = Category.Kids,
                //             IsFinal = true,
                //             OrderBy = 1,
                //             LengthInKilometers = 30,
                //             RestTimeInMinutes = 20,
                //             MaxRecoveryTimeInMinutes = 15,
                //             MaxSpeedInKpH = 20,
                //         }
                //     }
                // };
                //
                // var trial100 = new TrialDto
                // {
                //     StartTime = DateTime.Now,
                //     Type = CompetitionType.National,
                //     Phases = new List<PhaseDto>
                //     {
                //         new PhaseDto
                //         {
                //             Category = Category.Kids,
                //             IsFinal = false,
                //             OrderBy = 1,
                //             LengthInKilometers = 25,
                //             RestTimeInMinutes = 15,
                //             MaxRecoveryTimeInMinutes = 15,
                //             MaxSpeedInKpH = 20,
                //         },
                //         new PhaseDto
                //         {
                //             Category = Category.Kids,
                //             IsFinal = false,
                //             OrderBy = 1,
                //             LengthInKilometers = 35,
                //             RestTimeInMinutes = 20,
                //             MaxRecoveryTimeInMinutes = 15,
                //             MaxSpeedInKpH = 20,
                //         },
                //         new PhaseDto
                //         {
                //             Category = Category.Kids,
                //             IsFinal = true,
                //             OrderBy = 1,
                //             LengthInKilometers = 40,
                //             RestTimeInMinutes = 20,
                //             MaxRecoveryTimeInMinutes = 15,
                //             MaxSpeedInKpH = 20,
                //         }
                //     }
                // };
                //
                // var participant = new Participant(new List<TrialDto> { trial60, trial100 });
                //
                // participant.Start();
                //
                // participant.Participation.Arrive(DateTime.Now.AddMinutes(60));
                // participant.Participation.Inspect(DateTime.Now.AddMinutes(65));
                // participant.Participation.CompleteSuccessful();
                //
                // participant.Participation.StartNextPhase();
                //
                // participant.Participation.Arrive(DateTime.Now.AddMinutes(100));
                // participant.Participation.Inspect(DateTime.Now.AddMinutes(115));
                // participant.Participation.CompleteSuccessful();
                //
                // participant.Participation.StartNextPhase();
                //
                // participant.Participation.Arrive(DateTime.Now.AddMinutes(200));
                // participant.Participation.Inspect(DateTime.Now.AddMinutes(221));
                // participant.Participation.ReInspect(DateTime.Now.AddMinutes(225));
                // participant.Participation.CompleteUnsuccessful("KUR");
                ;

            }
        }
    }
}
