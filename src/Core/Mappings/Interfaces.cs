using AutoMapper;

namespace EnduranceContestManager.Core.Mappings
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
