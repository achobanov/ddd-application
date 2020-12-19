using EnduranceContestManager.Domain.Articles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnduranceContestManager.Gateways.Persistence.Configurations
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
