using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Events.Factories;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Common;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event = EnduranceJudge.Domain.Aggregates.Event.Events.Event;

namespace EnduranceJudge.Application.Events.Commands.SaveEvent
{
    public class SaveEvent : IRequest, IEventState
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

        public class SaveEventHandler : Handler<SaveEvent>
        {
            private readonly ICommandsBase<Event> eventCommands;
            private readonly IEventFactory eventFactory;
            private readonly IPersonnelFactory personnelFactory;
            private readonly ICountryQueries countryQueries;

            public SaveEventHandler(
                ICommandsBase<Event> eventCommands,
                IEventFactory eventFactory,
                IPersonnelFactory personnelFactory,
                ICountryQueries countryQueries)
            {
                this.eventCommands = eventCommands;
                this.eventFactory = eventFactory;
                this.personnelFactory = personnelFactory;
                this.countryQueries = countryQueries;
            }

            protected override async Task Handle(SaveEvent request, CancellationToken cancellationToken)
            {
                var _event = this.eventFactory.Create(request);
                var country = await this.countryQueries.Find(request.CountryIsoCode);

                _event.Set(country);
                this.AddPersonnel(_event, request);

                await this.eventCommands.Save(_event, cancellationToken);
            }

            private void AddPersonnel(Event _event, SaveEvent request)
            {
                var presidentGroundJury = this.personnelFactory.PresidentGroundJury(request.PresidentGroundJury);
                _event.Add(presidentGroundJury);

                var presidentVetCommission = this.personnelFactory.PresidentVetCommission(
                    request.PresidentVetCommission);

                _event.Add(presidentVetCommission);

                var feiTechDelegate = this.personnelFactory.FeiTechDelegate(request.FeiTechDelegate);
                _event.Add(feiTechDelegate);

                var feiVetDelegate = this.personnelFactory.FeiVetDelegate(request.FeiVetDelegate);
                _event.Add(feiVetDelegate);

                var foreignJudge = this.personnelFactory.ForeignJudge(request.ForeignJudge);
                _event.Add(foreignJudge);

                var activeVet = this.personnelFactory.ActiveVet(request.ActiveVet);
                _event.Add(activeVet);

                request.MembersOfJudgeCommittee
                    .Select(this.personnelFactory.MemberOfJudgeCommittee)
                    .ForEach(_event.Add);

                request.MembersOfVetCommittee
                    .Select(this.personnelFactory.MemberOfVetCommittee)
                    .ForEach(_event.Add);

                request.Stewards
                    .Select(this.personnelFactory.Steward)
                    .ForEach(_event.Add);
            }
        }
    }
}
