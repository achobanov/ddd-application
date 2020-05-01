using Blog.Domain.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Gateways.Persistence.Configurations
{
    public class ArticleConfiguration : AuditableEntityConfiguration<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            base.Configure(builder);

            builder.HasKey(a => a.Id);

            builder
                .HasMany(a => a.Comments)
                .WithOne(a => a.Article)
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
