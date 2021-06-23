﻿using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Create;
using EnduranceJudge.Application.Events.Factories;
using EnduranceJudge.Domain.Aggregates.Event.Personnels;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Application.Events.Services.Implementations
{
    public class EnduranceEventService : IEnduranceEventService
    {
        private readonly IPersonnelFactory personnelFactory;

        public EnduranceEventService(IPersonnelFactory personnelFactory)
        {
            this.personnelFactory = personnelFactory;
        }

        public IEnumerable<Personnel> PreparePersonnel(CreateEnduranceEvent request)
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