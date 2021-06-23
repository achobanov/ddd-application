using EnduranceJudge.Application.Events.Commands.EnduranceEvents;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using EnduranceJudge.Domain.Aggregates.Event.Personnels;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Application.Events.Factories.Implementations
{
    public class EnduranceEventFactory : IEnduranceEventFactory
    {
        private readonly ICompetitionFactory competitionFactory;
        private readonly IPersonnelFactory personnelFactory;

        public EnduranceEventFactory(ICompetitionFactory competitionFactory, IPersonnelFactory personnelFactory)
        {
            this.competitionFactory = competitionFactory;
            this.personnelFactory = personnelFactory;
        }

        public EnduranceEvent Create(SaveEnduranceEvent data)
        {
            var enduranceEvent = new EnduranceEvent(data);

            foreach (var competitionData in data.Competitions)
            {
                var competition = this.competitionFactory.Create(competitionData);
                enduranceEvent.Add(competition);
            }

            var personnel = this.PreparePersonnel(data);
            personnel.ForEach(enduranceEvent.Add);

            return enduranceEvent;
        }

        private IEnumerable<Personnel> PreparePersonnel(SaveEnduranceEvent request)
        {
            var feiTechDelegate = this.personnelFactory.FeiTechDelegate(request.FeiTechDelegate);
            var feiVetDelegate = this.personnelFactory.FeiVetDelegate(request.FeiVetDelegate);
            var foreignJudge = this.personnelFactory.ForeignJudge(request.ForeignJudge);
            var activeVet = this.personnelFactory.ActiveVet(request.ActiveVet);
            var presidentGroundJury = this.personnelFactory.PresidentGroundJury(request.PresidentGroundJury);
            var presidentVetCommission = this.personnelFactory.PresidentVetCommission(
                request.PresidentVetCommission);

            var membersOfJudgeCommittee = request.MembersOfJudgeCommittee.Select(
                this.personnelFactory.MemberOfJudgeCommittee);

            var membersOfVetCommittee = request.MembersOfVetCommittee.Select(
                this.personnelFactory.MemberOfVetCommittee);

            var stewards = request.Stewards.Select(this.personnelFactory.Steward);

            var list = new List<Personnel>
            {
                feiTechDelegate,
                feiVetDelegate,
                foreignJudge,
                activeVet,
                presidentGroundJury,
                presidentVetCommission,
            };

            list.AddRange(membersOfJudgeCommittee);
            list.AddRange(membersOfVetCommittee);
            list.AddRange(stewards);

            return list;
        }
    }
}
