using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Application.Contracts.Events;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Common.Countries;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using EnduranceJudge.Domain.Aggregates.Event.Participants;
using EnduranceJudge.Domain.Aggregates.Event.Phases;
using EnduranceJudge.Domain.Aggregates.Event.PhasesForCategory;
using EnduranceJudge.Domain.Enums;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Test
{
    public class Test : IRequest
    {
        public string Name { get; set; }

        public class TestHandler : Handler<Test>
        {
            private readonly IEventCommands eventCommands;
            private readonly ICountryQueries countryQueries;

            public TestHandler(IEventCommands eventCommands, ICountryQueries countryQueries)
            {
                this.eventCommands = eventCommands;
                this.countryQueries = countryQueries;
            }

            protected override async Task Handle(Test request, CancellationToken cancellationToken)
            {
                await this.BigTest(cancellationToken);
            }

            private async Task BigTest(CancellationToken cancellationToken)
            {
                var event_ = new Event("Name", "place");

                var competition1 = new Competition(CompetitionType.National);

                var participant1 = new Participant("111", 11);
                var horse1 = new Horse();
                var athlete1 = new Athlete(Category.Kids);
                var participant2 = new Participant("222", 22);
                var horse2 = new Horse();
                var athlete2 = new Athlete(Category.Kids);
                var participant3 = new Participant("333", 33);
                var horse3 = new Horse();
                var athlete3 = new Athlete(Category.Adults);
                var participant4 = new Participant("444", 44);
                var horse4 = new Horse();
                var athlete4 = new Athlete(Category.Adults);

                var phase1 = new Phase(15);
                var phaseForCategory1 = new PhaseForCategory(10, 15, Category.Kids);
                var phaseForCategory2 = new PhaseForCategory(10, 15, Category.Adults);

                var phase2 = new Phase(25, true);
                var phaseForCategory3 = new PhaseForCategory(20, 25, Category.Kids);
                var phaseForCategory4 = new PhaseForCategory(20, 25, Category.Adults);

                var competition2 = new Competition(CompetitionType.International);
                var participant5= new Participant("111", 11);
                var horse5= new Horse();
                var athlete5= new Athlete(Category.Kids);
                var participant6= new Participant("222", 22);
                var horse6= new Horse();
                var athlete6= new Athlete(Category.Kids);
                var participant7 = new Participant("333", 33);
                var horse7 = new Horse();
                var athlete7 = new Athlete(Category.Adults);
                var participant8 = new Participant("444", 44);
                var horse8 = new Horse();
                var athlete8 = new Athlete(Category.Adults);

                var phase3 = new Phase(30, true);
                var phaseForCategory5 = new PhaseForCategory(10, 15, Category.Kids);
                var phaseForCategory6 = new PhaseForCategory(10, 15, Category.Adults);

                var presidentJury = new Personnel("Gosho Prezidenta", PersonnelRole.PresidentGroundJury);
                var activeVet = new Personnel("House MD", PersonnelRole.ActiveVet);
                var vetMember1 = new Personnel("Vet One", PersonnelRole.MemberOfVetCommittee);
                var vetMember2 = new Personnel("Vet Two", PersonnelRole.MemberOfVetCommittee);

                var country = await this.countryQueries.Find("BUL");

                event_.Add(competition1);
                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Add(competition2);
                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                // Competition 1
                participant1
                    .Set(horse1)
                    .Set(athlete1);

                participant2
                    .Set(horse2)
                    .Set(athlete2);

                participant3
                    .Set(horse3)
                    .Set(athlete3);

                participant4
                    .Set(horse4)
                    .Set(athlete4);

                event_.Competitions.First(x => x.Id == 1)
                    .Add(participant1)
                    .Add(participant2)
                    .Add(participant3)
                    .Add(participant4);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Competitions.First(x => x.Id == 1)
                    .Add(phase1);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Competitions.First(x => x.Id == 1)
                    .Phases.First(x => x.Id == 1)
                    .Add(phaseForCategory1);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Competitions.First(x => x.Id == 1)
                    .Phases.First(x => x.Id == 1)
                    .Add(phaseForCategory2);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Competitions.First(x => x.Id == 1)
                    .Add(phase2);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Competitions.First(x => x.Id == 1)
                    .Phases.First(x => x.Id == 2)
                    .Add(phaseForCategory3);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Competitions.First(x => x.Id == 1)
                    .Phases.First(x => x.Id == 2)
                    .Add(phaseForCategory4);

                // Competition 2
                participant5
                    .Set(horse5)
                    .Set(athlete5);

                participant6
                    .Set(horse6)
                    .Set(athlete6);

                participant7
                    .Set(horse7)
                    .Set(athlete7);

                participant8
                    .Set(horse8)
                    .Set(athlete8);

                event_.Competitions.First(x => x.Id == 2)
                    .Add(participant5)
                    .Add(participant6)
                    .Add(participant7)
                    .Add(participant8);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Competitions.First(x => x.Id == 2)
                    .Add(phase3);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Competitions.First(x => x.Id == 2)
                    .Phases.First(x => x.Id == 3)
                    .Add(phaseForCategory5);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Competitions.First(x => x.Id == 2)
                    .Phases.First(x => x.Id == 3)
                    .Add(phaseForCategory6);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                // Event
                event_.Add(presidentJury);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Add(activeVet);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Add(vetMember1);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                event_.Add(vetMember2);

                await this.eventCommands.Save(event_, cancellationToken);
                event_ = await this.eventCommands.Find(1);

                // event_.Set(country);
                //
                // await this.eventCommands.Save(event_, cancellationToken);
                // event_ = await this.eventCommands.Find(1);

                event_.Remove(event_.Competitions.First());
                event_.Add(new Competition(CompetitionType.International));
                await this.eventCommands.Save(event_, cancellationToken);

                event_ = await this.eventCommands.Find(1);
                ;
            }

            private async Task Create(CancellationToken cancellationToken)
            {
                var event_ = new Event("Name", "place");
                var competition1 = new Competition(CompetitionType.International);
                var competition2 = new Competition(CompetitionType.National);
                var competition3 = new Competition(CompetitionType.National);

                event_.Add(competition1);
                event_.Add(competition2);
                event_.Add(competition3);

                await this.eventCommands.Save(event_, cancellationToken);
            }

            private async Task Modify(CancellationToken cancellationToken)
            {
                var event_ = await this.eventCommands.Find<Event>(1);
                var toRemove = event_.Competitions.First();
                var toRemove2 = event_.Competitions.Last();
                event_.Remove(toRemove);
                event_.Remove(toRemove2);

                // await this.eventCommands.Save(event_, cancellationToken);

                var competition2 = new Competition(CompetitionType.National);
                event_.Add(competition2);

                await this.eventCommands.Save(event_, cancellationToken);
            }
        }
    }
}
