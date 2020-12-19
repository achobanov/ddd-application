using System;
using EnduranceContestManager.Common.Mappings;
using EnduranceContestManager.Domain.Articles;

namespace EnduranceContestManager.Application.Articles.Queries
{
    public class ArticleDetailsModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }

        public string CreatedBy { get; set; }

        public string Author { get; set; }
    }
}
