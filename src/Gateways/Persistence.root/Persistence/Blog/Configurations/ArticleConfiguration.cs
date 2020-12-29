using EnduranceContestManager.Domain.Articles;
using EnduranceContestManager.Gateways.Persistence.Core.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnduranceContestManager.Gateways.Persistence.Blog.Configurations
{
    public class ArticleConfiguration : AuditableEntityConfiguration<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            base.Configure(builder);

            builder.HasKey(a => a.Id);
        }
    }
}
