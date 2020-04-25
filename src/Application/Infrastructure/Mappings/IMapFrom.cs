using AutoMapper;

namespace Blog.Application.Infrastructure.Mappings
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile mapper) => mapper.CreateMap(typeof(T), this.GetType());
    }
}
