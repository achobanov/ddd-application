using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Application.Events.Services;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Events.Commands.EnduranceEvents.Create
{
    public class CreateEnduranceEvent : IRequest<EnduranceEventForUpdateModel>, IEnduranceEventState
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public string PopulatedPlace { get; set; }
        public string CountryIsoCode { get; set; }
        public string PresidentGroundJury { get; set; }
        public string PresidentVetCommission { get; set; }
        public string ForeignJudge { get; set; }
        public string FeiTechDelegate { get; set; }
        public string FeiVetDelegate { get; set; }
        public string ActiveVet { get; set; }
        public IEnumerable<string> MembersOfVetCommittee { get; set; }
        public IEnumerable<string> MembersOfJudgeCommittee { get; set; }
        public IEnumerable<string> Stewards { get; set; }

        public IEnumerable<CompetitionDependantModel> Competitions { get; set;}

        public class CreateEnduranceEventHandler : Handler<CreateEnduranceEvent, EnduranceEventForUpdateModel>
        {
            private readonly ICommandsBase<EnduranceEvent> eventCommands;
            private readonly ICountryQueries countryQueries;
            private readonly IEnduranceEventService enduranceEventService;

            public CreateEnduranceEventHandler(
                ICommandsBase<EnduranceEvent> eventCommands,
                ICountryQueries countryQueries,
                IEnduranceEventService enduranceEventService)
            {
                this.eventCommands = eventCommands;
                this.countryQueries = countryQueries;
                this.enduranceEventService = enduranceEventService;
            }

            public override async Task<EnduranceEventForUpdateModel> Handle(
                CreateEnduranceEvent request,
                CancellationToken cancellationToken)
            {
                var enduranceEvent = new EnduranceEvent(request);

                var competitions = request
                    .Competitions
                    ?.Select(x => new Competition(x.Id, x.Type, x.Name))
                    .ToList();

                foreach (var competition in competitions)
                {
                    enduranceEvent.Add(competition);
                }

                var personnel = this.enduranceEventService.PreparePersonnel(request);
                personnel.ForEach(enduranceEvent.Add);

                var country = await this.countryQueries.Find(request.CountryIsoCode);
                enduranceEvent.Set(country);

                var result = await this.eventCommands.Save<EnduranceEventForUpdateModel>(
                    enduranceEvent,
                    cancellationToken);

                return result;
            }
        }
    }
}
