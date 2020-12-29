using EnduranceContestManager.Application.Interfaces.Base;
using EnduranceContestManager.Domain.Articles;

namespace EnduranceContestManager.Application.Interfaces.Blog.Articles
{
    public interface IArticleQueries : IQueryRepository<Article>
    {
    }
}