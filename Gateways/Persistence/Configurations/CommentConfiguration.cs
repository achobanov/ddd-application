﻿using Blog.Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Gateways.Persistence.Configurations
{
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