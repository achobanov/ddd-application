using MediatR;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Interfaces.Contests;
using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Event.Events;

namespace EnduranceJudge.Application.Contests.Commands
{
    public class CreateEvent : IRequest<int>, IEventState
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

        public class CreateContestHandler : CreateHandler<CreateEvent, Event>
        {
            public CreateContestHandler(IContestFactory factory, IContestCommands commands)
                : base(factory, commands)
            {
            }
        }
    }
}
