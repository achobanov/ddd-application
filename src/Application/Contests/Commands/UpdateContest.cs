using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Application.Interfaces.Events;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using System.Collections.Generic;

namespace EnduranceJudge.Application.Contests.Commands
{
    public class UpdateEvent : IIdentifiableRequest, IEventState, IMapTo<Event>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PopulatedPlace { get; set; }

        public string Country { get; set; }

        public string PresidentGroundJury { get; set; }

        public string FeiTechDelegate { get; set; }

        public string PresidentVetCommission { get; set; }

        public string FeiVetDelegate { get; set; }

        public string ForeignJudge { get; set; }

        public string ActiveVet { get; set; }

        public IList<string> MembersOfVetCommittee { get; set; }

        public IList<string> MembersOfJudgeCommittee { get; set; }

        public IList<string> Stewards { get; set; }

        public IList<Competition> Competitions { get; set; }

        public class UpdateContestHandler : UpdateHandler<UpdateEvent, Event>
        {
            public UpdateContestHandler(IEventCommands commands)
                : base(commands)
            {
            }
        }
    }
}
