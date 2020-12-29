using EnduranceContestManager.Application.Interfaces.Blog.Articles;
using EnduranceContestManager.Domain.Blog.Articles;
using EnduranceContestManager.Gateways.Persistence.Core;

namespace EnduranceContestManager.Gateways.Persistence.Blog
{
    public class ArticlesRepository : Repository<IBlogDbContext, Article>,
        IArticleCommands,
        IArticleQueries
    {
        public ArticlesRepository(IBlogDbContext db)
            : base(db)
        {
        }
    }
}