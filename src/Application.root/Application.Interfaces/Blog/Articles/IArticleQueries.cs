using EnduranceContestManager.Application.Interfaces.Base;
using EnduranceContestManager.Domain.Blog.Articles;

namespace EnduranceContestManager.Application.Interfaces.Blog.Articles
{
    public interface IArticleQueries : IQueryRepository<Article>
    {
    }
}