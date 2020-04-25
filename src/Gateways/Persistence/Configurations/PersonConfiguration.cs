namespace Blog.Gateways.Persistence.Configurations
{
    using Blog.Domain.Authors;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(u => u.Id);

            builder
                .Property(u => u.Username);

            builder
                .HasMany(u => u.Articles)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Comments)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
