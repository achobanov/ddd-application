using MediatR;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Gateways.Persistence.Data.Contests;
using System.Collections.Generic;

namespace EnduranceContestManager.Application.Contests.Commands
{
    public class CreateContest : IRequest<int>, IContestState
    {
        public string Name { get; set; }

        public string PopulatedPlace { get; set; }

        public string Country { get; set; }

        public string PresidentGroundJury { get; set; }

        public string FeiTechDelegate { get; set; }

        public string PresidentVetCommission { get; set; }

        public string FeiVetDelegate { get; set; }

        public string ForeignJudge { get; set; }

        public string ActiveVet { get; set; }

        public IList<string> MembersOfJudgeCommittee { get; set; }

        public IList<string> MembersOfVetCommittee { get; set; }

        public IList<string> Stewards { get; set; }

        public IList<Trial> Trials { get; set; }

        public class CreateContestHandler : CreateHandler<Contest, ContestData, CreateContest>
        {
            public CreateContestHandler(IContestFactory factory, IContestCommands commands)
                : base(factory, commands)
            {
            }
        }
    }
}
