using Entity.Concretes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFrameworks.Mappings
{
    public class InformationMapping : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> entity)
        {
            entity.HasKey(e => e.InfoId);

            entity.Property(e => e.InfoId).HasColumnName("InfoID");

            entity.Property(e => e.Format)
                            .HasMaxLength(10)
                            .IsFixedLength();

            entity.Property(e => e.SendDate).HasColumnType("datetime");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.Task)
                            .WithMany(p => p.Informations)
                            .HasForeignKey(d => d.TaskId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Informations_Tasks");
        }
    }
}
