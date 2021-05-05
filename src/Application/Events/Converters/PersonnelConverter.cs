using AutoMapper;
using EnduranceJudge.Core;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceJudge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Application.Events.Converters
{
    public class PersonnelConverter : IValueConverter<IEnumerable<Personnel>, string>
    {
        private readonly PersonnelRole role;
        private readonly bool isMultiPersonnelRole = false;

        public static PersonnelConverter New(PersonnelRole role)
            => new PersonnelConverter(role);

        public PersonnelConverter(PersonnelRole role)
        {
            this.role = role;
            // TODO: Extract this logic in Event domain entity
            if (role is PersonnelRole.MemberOfJudgeCommittee
                || role is PersonnelRole.MemberOfVetCommittee
                || role is PersonnelRole.Steward)
            {
                this.isMultiPersonnelRole = true;
            }
        }

        public string Convert(IEnumerable<Personnel> sourceMember, ResolutionContext context)
        {
            Func<Personnel, bool> filter = x => x.Role == this.role;
            if (this.isMultiPersonnelRole)
            {
                var personnelNames = sourceMember
                    .Where(filter)
                    .Select(x => x.Name)
                    .ToList();

                var joinedNames = string.Join(CoreConstants.StringSplitChar, personnelNames);
                return joinedNames;
            }

            var personnel = sourceMember.SingleOrDefault(x => x.Role == this.role);
            return personnel?.Name;
        }
    }
}
