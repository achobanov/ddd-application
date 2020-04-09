namespace Blog.Gateways.Persistence.Configurations
{
    using Blog.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder
                .Property(u => u.Username)
                .IsRequired();

            builder
                .HasMany(u => u.Articles)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Comments)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
