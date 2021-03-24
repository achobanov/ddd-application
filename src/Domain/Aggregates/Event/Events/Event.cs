using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceJudge.Domain.Core.Exceptions;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Core.Extensions;
using EnduranceJudge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Event.Events
{
    public class Event : BaseEvent<EventException>, IAggregateRoot
    {
        public Event(int id, string name, string populatedPlace)
            : base(id, name, populatedPlace)
        {
        }

        private List<Personnel> personnel = new();
        public IReadOnlyList<Personnel> Personnel
        {
            get => this.personnel.AsReadOnly();
            private set => this.personnel = value.ToList();
        }
        public Event Add(Personnel personnel)
        {
            var areRoleDuplicatesAllowed = personnel.Role == PersonnelRole.MemberOfJudgeCommittee
                || personnel.Role == PersonnelRole.MemberOfVetCommittee;

            if (areRoleDuplicatesAllowed && this.personnel.Any(p => p.Name == personnel.Name))
            {
                var message = $"Cannot add {personnel.Role}' - name '{personnel.Name}' already exits";
                Thrower.Throw<EventException>(message);
            }

            if (!areRoleDuplicatesAllowed && this.personnel.Any(p => p.Role == personnel.Role))
            {
                var message = $"Cannot add {personnel.Role} - it already exits";
                Thrower.Throw<EventException>(message);
            }

            this.Add(e => e.personnel, personnel);
            return this;
        }
        public Event Remove(Personnel personnel)
        {
            this.Remove(x => x.personnel, personnel);
            return this;
        }

        private List<Competition> competitions = new();
        public IReadOnlyList<Competition> Competitions
        {
            get => this.competitions.AsReadOnly();
            private set => this.competitions = value.ToList();
        }
        public Event Add(Competition competition)
        {
            this.Add(x => x.competitions, competition);
            return this;
        }
        public Event Remove(Func<Competition, bool> filter)
        {
            var competition = this.competitions.FirstOrDefault(filter);
            return this.Remove(competition);
        }
        public Event Remove(Competition competition)
        {
            this.Remove(x => x.competitions, competition);
            return this;
        }
    }
}
