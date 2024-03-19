using Microsoft.EntityFrameworkCore;
using CleanArchitectureV2._0.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureV2._0.Persistence.Configure
{
    public class UserConfigure : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(e => e.Email);

            builder.Property<string>(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property<string>(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
