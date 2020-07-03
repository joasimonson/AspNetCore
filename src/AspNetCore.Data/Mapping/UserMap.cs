using AspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("TB_USER");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p=> p.Email).HasMaxLength(100);
        }
    }
}