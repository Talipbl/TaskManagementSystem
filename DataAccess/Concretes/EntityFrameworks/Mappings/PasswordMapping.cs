using Entity.Concretes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFrameworks.Mappings
{
    public class PasswordMapping : IEntityTypeConfiguration<Password>
    {
        public void Configure(EntityTypeBuilder<Password> entity)
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");

            entity.Property(e => e.PasswordHash).HasMaxLength(500);

            entity.Property(e => e.PasswordSalt).HasMaxLength(500);

            entity.HasOne(d => d.User)
                .WithOne(p => p.Password)
                .HasForeignKey<Password>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Passwords_Users");
        }
    }
}
