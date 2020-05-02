using AutoMapper;

namespace Blog.Common.Mappings
{
    public interface IMapFrom<T> : IMapCreator
    {
        void IMapCreator.CreateMap(Profile profile) => profile.CreateMap(typeof(T), this.GetType());
    }

    public interface IMapTo<T> : IMapCreator
    {
        void IMapCreator.CreateMap(Profile profile) => profile.CreateMap(this.GetType(), typeof(T));
    }

    public interface IMapExplicitly
    {
        void CreateMap(Profile profile);
    }

    public interface IMapCreator
    {
        void CreateMap(Profile profile);
    }
}
