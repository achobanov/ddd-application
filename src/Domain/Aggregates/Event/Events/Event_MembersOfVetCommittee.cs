using EnduranceJudge.Domain.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        private readonly List<Personnel> membersOfVetCommittee = new();

        public IReadOnlyList<Personnel> MembersOfVetCommittee => this.membersOfVetCommittee.AsReadOnly();

        public Event AddMembersOfVetCommittee(Personnel personnel)
        {
            this.Add(
                contest => contest.membersOfVetCommittee,
                personnel);

            return this;
        }

        public Event RemoveMemberOfVetCommittee(Func<Personnel, bool> filter)
        {
            var personnel = this.membersOfVetCommittee.FirstOrDefault(filter);
            this.Remove(
                contest => contest.membersOfVetCommittee,
                personnel);

            return this;
        }
    }
}
