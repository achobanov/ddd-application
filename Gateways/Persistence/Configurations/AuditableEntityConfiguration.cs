using Blog.Domain.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Gateways.Persistence.Configurations
{
    public class AuditableEntityConfiguration : IEntityTypeConfiguration<AuditableEntity>
    {
        public void Configure(EntityTypeBuilder<AuditableEntity> builder)
        {
            builder
                .Property(x => x.CreatedOn)
                .IsRequired();

            builder
                .Property(x => x.CreatedBy)
                .IsRequired();
        }
    }
}
