using AutoMapper;
using System;
using System.Collections.Generic;

namespace EnduranceJudge.Core.Mappings.Converters
{
    public class StringSplitter : IValueConverter<string, IEnumerable<string>>
    {
        public static StringSplitter New => new StringSplitter();

        public IEnumerable<string> Convert(string sourceMember, ResolutionContext context)
        {
            var values = sourceMember.Split(CoreConstants.StringSplitChar, StringSplitOptions.RemoveEmptyEntries);
            return values;
        }
    }
}
