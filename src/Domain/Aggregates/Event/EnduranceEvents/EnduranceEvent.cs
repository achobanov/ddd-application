using EnduranceJudge.Domain.Aggregates.Common.Countries;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.Personnels;
using EnduranceJudge.Domain.Core.Exceptions;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents
{
    public class EnduranceEvent : DomainModel<EnduranceEventException>, IAggregateRoot
    {
        private EnduranceEvent()
        {
        }

        public EnduranceEvent(string name, string populatedPlace)
            => this.Validate(() =>
            {
                this.Name = name.IsRequired(nameof(name));
                this.PopulatedPlace = populatedPlace.IsRequired(nameof(populatedPlace));
            });

        public string Name { get; protected set; }
        public string PopulatedPlace { get; protected set; }

        public Country Country { get; protected set; }
        public void Set(Country country)
            => this.Validate(() =>
            {
                this.Country = country.IsRequired(nameof(country));
            });

        private List<Personnel> personnel = new();
        public IReadOnlyList<Personnel> Personnel
        {
            get => this.personnel.AsReadOnly();
            private set => this.personnel = value.ToList();
        }
        public EnduranceEvent Add(Personnel personnel)
        {
            var areRoleDuplicatesAllowed = personnel.Role == PersonnelRole.MemberOfJudgeCommittee
                || personnel.Role == PersonnelRole.MemberOfVetCommittee;

            if (areRoleDuplicatesAllowed && this.personnel.Any(p => p.Name == personnel.Name))
            {
                var message = $"Cannot add {personnel.Role}' - name '{personnel.Name}' already exits";
                Thrower.Throw<EnduranceEventException>(message);
            }

            if (!areRoleDuplicatesAllowed && this.personnel.Any(p => p.Role == personnel.Role))
            {
                var message = $"Cannot add {personnel.Role} - it already exits";
                Thrower.Throw<EnduranceEventException>(message);
            }

            this.personnel.ValidateAndAdd(personnel);
            return this;
        }
        public EnduranceEvent Remove(Personnel personnel)
        {
            this.personnel.ValidateAndRemove(personnel);
            return this;
        }

        private List<Competition> competitions = new();
        public IReadOnlyList<Competition> Competitions
        {
            get => this.competitions.AsReadOnly();
            private set => this.competitions = value.ToList();
        }
        public EnduranceEvent Add(Competition competition)
        {
            this.competitions.ValidateAndAdd(competition);
            return this;
        }
        public EnduranceEvent Remove(Func<Competition, bool> filter)
        {
            var competition = this.competitions.FirstOrDefault(filter);
            return this.Remove(competition);
        }
        public EnduranceEvent Remove(Competition competition)
        {
            this.competitions.ValidateAndRemove(competition);
            return this;
        }
    }
}
