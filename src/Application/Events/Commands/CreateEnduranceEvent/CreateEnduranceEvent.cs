using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Events.Commands.CreateEnduranceEvent.Models;
using EnduranceJudge.Application.Events.Factories;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Events.Commands.CreateEnduranceEvent
{
    public class CreateEnduranceEvent : IRequest, IEnduranceEventState
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

        public IEnumerable<CreateCompetitionModel> Competitions { get; set;}

        public class SaveEnduranceEventHandler : Handler<CreateEnduranceEvent>
        {
            private readonly ICommandsBase<EnduranceEvent> eventCommands;
            private readonly IPersonnelFactory personnelFactory;
            private readonly ICountryQueries countryQueries;

            public SaveEnduranceEventHandler(
                ICommandsBase<EnduranceEvent> eventCommands,
                IPersonnelFactory personnelFactory,
                ICountryQueries countryQueries)
            {
                this.eventCommands = eventCommands;
                this.personnelFactory = personnelFactory;
                this.countryQueries = countryQueries;
            }

            protected override async Task Handle(CreateEnduranceEvent request, CancellationToken cancellationToken)
            {
                var enduranceEvent = await this.eventCommands.Find(request.Id);
                if (enduranceEvent == null)
                {
                    enduranceEvent = new EnduranceEvent(request);

                    request.Competitions
                        .Select(x => new Competition(x.Id, x.Type))
                        .ForEach(enduranceEvent.Add);
                }
                else
                {
                    enduranceEvent.Update(request);
                }

                if (enduranceEvent.Country?.IsoCode != request.CountryIsoCode)
                {
                    var country = await this.countryQueries.Find(request.CountryIsoCode);
                    enduranceEvent.Set(country);
                }

                this.AddPersonnel(enduranceEvent, request);

                await this.eventCommands.Save(enduranceEvent, cancellationToken);
            }

            private void AddPersonnel(EnduranceEvent enduranceEvent, CreateEnduranceEvent request)
            {
                var feiTechDelegate = this.personnelFactory.FeiTechDelegate(request.FeiTechDelegate);
                var feiVetDelegate = this.personnelFactory.FeiVetDelegate(request.FeiVetDelegate);
                var foreignJudge = this.personnelFactory.ForeignJudge(request.ForeignJudge);
                var activeVet = this.personnelFactory.ActiveVet(request.ActiveVet);
                var presidentGroundJury = this.personnelFactory.PresidentGroundJury(request.PresidentGroundJury);
                var presidentVetCommission = this.personnelFactory.PresidentVetCommission(
                    request.PresidentVetCommission);

                var membersOfJudgeCommittee = request.MembersOfVetCommittee.Select(
                    this.personnelFactory.MemberOfJudgeCommittee);

                var membersOfVetCommittee = request.MembersOfVetCommittee.Select(
                    this.personnelFactory.MemberOfVetCommittee);

                var stewards = request.Stewards.Select(this.personnelFactory.Steward);

                enduranceEvent
                    .ClearPersonnel()
                    .Add(presidentGroundJury)
                    .Add(presidentVetCommission)
                    .Add(feiTechDelegate)
                    .Add(feiVetDelegate)
                    .Add(foreignJudge)
                    .Add(activeVet)
                    .Add(membersOfJudgeCommittee)
                    .Add(membersOfVetCommittee)
                    .Add(stewards);
            }
        }
    }
}
