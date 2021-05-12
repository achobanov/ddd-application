using AutoMapper;
using EnduranceJudge.Core;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Gateways.Persistence.Converters
{
    public class PersonnelConverter : IValueConverter<IEnumerable<PersonnelEntity>, string>
    {
        private readonly PersonnelRole role;
        private readonly bool isMultiPersonnelRole;

        public PersonnelConverter(PersonnelRole role)
        {
            this.role = role;
            this.isMultiPersonnelRole = EnduranceEvent.IsRoleMultiPersonnel(role);
        }

        public string Convert(IEnumerable<PersonnelEntity> sourceMember, ResolutionContext context)
        {
            if (this.isMultiPersonnelRole)
            {
                var personnelNames = sourceMember
                    .Where(x => x.Role == this.role)
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
