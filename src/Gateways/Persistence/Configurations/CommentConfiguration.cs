namespace Blog.Gateways.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Content)
                .IsRequired();

            builder
                .Property(a => a.CreatedBy)
                .IsRequired();

            builder
                .HasOne(c => c.Author)
                .WithMany(u => u.Comments)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
