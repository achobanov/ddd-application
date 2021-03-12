using AutoMapper;

namespace EnduranceJudge.Core.Mappings
{
    public interface IMapFrom<T>
    {
    }

    public interface IMapTo<T>
    {
    }

    public interface IMapExplicitly
    {
        void CreateExplicitMap(Profile mapper);
    }
}
