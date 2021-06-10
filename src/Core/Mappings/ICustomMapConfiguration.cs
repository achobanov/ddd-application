using AutoMapper;

namespace EnduranceJudge.Core.Mappings
{
    public interface ICustomMapConfiguration
    {
        void AddMaps(IProfileExpression profile);
    }
}
