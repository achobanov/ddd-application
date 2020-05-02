using System;
using AutoMapper;
using Blog.Common.Mappings;
using Blog.Domain.Articles;

namespace Blog.Application.Articles.Queries
{
    public class ArticleDetailsModel : IMapFrom<Article>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }

        public string CreatedBy { get; set; }

        public string Author { get; set; }

        public int CommmentsCount { get; set; }

        public void CreateMap(Profile profile)
            => profile
                .CreateMap<Article, ArticleDetailsModel>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Username))
                .ForMember(dest => dest.CommmentsCount, opt => opt.MapFrom(src => src.Comments.Count));
    }
}
