using Blog.Domain.Comments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Gateways.Persistence.Configurations
{
    public class CommentConfiguration : AuditableEntityConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);

            builder.HasKey(a => a.Id);
        }
    }
}
