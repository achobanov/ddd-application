using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Events.Factories;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Events.Commands.SaveEnduranceEvent
{
    public class SaveEnduranceEvent : IRequest, IEnduranceEventState
    {
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

        public class SaveEnduranceEventHandler : Handler<SaveEnduranceEvent>
        {
            private readonly ICommandsBase<EnduranceEvent> eventCommands;
            private readonly IEnduranceEventFactory enduranceEventFactory;
            private readonly IPersonnelFactory personnelFactory;
            private readonly ICountryQueries countryQueries;

            public SaveEnduranceEventHandler(
                ICommandsBase<EnduranceEvent> eventCommands,
                IEnduranceEventFactory enduranceEventFactory,
                IPersonnelFactory personnelFactory,
                ICountryQueries countryQueries)
            {
                this.eventCommands = eventCommands;
                this.enduranceEventFactory = enduranceEventFactory;
                this.personnelFactory = personnelFactory;
                this.countryQueries = countryQueries;
            }

            protected override async Task Handle(SaveEnduranceEvent request, CancellationToken cancellationToken)
            {
                var enduranceEvent = this.enduranceEventFactory.Create(request);
                var country = await this.countryQueries.Find(request.CountryIsoCode);

                enduranceEvent.Set(country);
                this.AddPersonnel(enduranceEvent, request);

                await this.eventCommands.Save(enduranceEvent, cancellationToken);
            }

            private void AddPersonnel(EnduranceEvent enduranceEvent, SaveEnduranceEvent request)
            {
                var presidentGroundJury = this.personnelFactory.PresidentGroundJury(request.PresidentGroundJury);
                enduranceEvent.Add(presidentGroundJury);

                var presidentVetCommission = this.personnelFactory.PresidentVetCommission(
                    request.PresidentVetCommission);

                enduranceEvent.Add(presidentVetCommission);

                var feiTechDelegate = this.personnelFactory.FeiTechDelegate(request.FeiTechDelegate);
                enduranceEvent.Add(feiTechDelegate);

                var feiVetDelegate = this.personnelFactory.FeiVetDelegate(request.FeiVetDelegate);
                enduranceEvent.Add(feiVetDelegate);

                var foreignJudge = this.personnelFactory.ForeignJudge(request.ForeignJudge);
                enduranceEvent.Add(foreignJudge);

                var activeVet = this.personnelFactory.ActiveVet(request.ActiveVet);
                enduranceEvent.Add(activeVet);

                request.MembersOfJudgeCommittee
                    .Select(this.personnelFactory.MemberOfJudgeCommittee)
                    .ForEach(enduranceEvent.Add);

                request.MembersOfVetCommittee
                    .Select(this.personnelFactory.MemberOfVetCommittee)
                    .ForEach(enduranceEvent.Add);

                request.Stewards
                    .Select(this.personnelFactory.Steward)
                    .ForEach(enduranceEvent.Add);
            }
        }
    }
}
