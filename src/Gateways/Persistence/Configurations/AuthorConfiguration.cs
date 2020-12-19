using EnduranceContestManager.Domain.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnduranceContestManager.Gateways.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(u => u.Id);

            builder
                .HasMany(aut => aut.Articles)
                .WithOne(art => art.Author)
                .HasForeignKey(art => art.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(aut => aut.Comments)
                .WithOne(art => art.Author)
                .HasForeignKey(art => art.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
