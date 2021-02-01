using AutoMapper;

namespace EnduranceContestManager.Core.Mappings
{
    public interface IMapFrom<T> : IMapFrom
    {
        void IMapFrom.CreateFromMap(Profile mapper) => mapper.CreateMap(typeof(T), this.GetType());
    }

    public interface IMapTo<T> : IMapTo
    {
        void IMapTo.CreateToMap(Profile mapper) => mapper.CreateMap(this.GetType(), typeof(T));
    }

    public interface IMapExplicitly
    {
        void CreateExplicitMap(Profile mapper);
    }

    public interface IMapFrom
    {
        void CreateFromMap(Profile mapper);
    }

    public interface IMapTo
    {
        void CreateToMap(Profile mapper);
    }
}
