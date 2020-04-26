using AutoMapper;

namespace Blog.Common.Mappings
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile mapper) => mapper.CreateMap(typeof(T), this.GetType());
    }
}
