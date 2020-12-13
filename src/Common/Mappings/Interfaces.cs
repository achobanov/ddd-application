using AutoMapper;

namespace Blog.Common.Mappings
{
    public interface IMapFrom<T> : IMapCreator
    {   
        void IMapCreator.CreateMap(Profile mapper) => mapper.CreateMap(typeof(T), this.GetType());
    }

    public interface IMapTo<T> : IMapCreator
    {
        void IMapCreator.CreateMap(Profile mapper) => mapper.CreateMap(this.GetType(), typeof(T));
    }

    public interface IMapExplicitly : IMapCreator
    {
    }

    public interface IMapCreator
    {
        void CreateMap(Profile mapper);
    }
}
