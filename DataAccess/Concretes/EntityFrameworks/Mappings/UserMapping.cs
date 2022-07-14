using Entity.Concretes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFrameworks.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.Property(e => e.FirstName).HasMaxLength(50);

            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.Property(e => e.MailAdress).HasMaxLength(50);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength();
        }
    }
}
