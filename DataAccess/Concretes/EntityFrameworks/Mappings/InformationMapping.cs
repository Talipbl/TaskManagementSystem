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

            entity.Property(e => e.FromId).HasColumnName("FromID");

            entity.Property(e => e.SendDate).HasColumnType("datetime");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.Property(e => e.ToId).HasColumnName("ToID");

            entity.HasOne(d => d.UserFrom)
                            .WithMany(p => p.InformationFroms)
                            .HasForeignKey(d => d.FromId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Informations_Users");

            entity.HasOne(d => d.Task)
                            .WithMany(p => p.Informations)
                            .HasForeignKey(d => d.TaskId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Informations_Tasks");

            entity.HasOne(d => d.UserTo)
                            .WithMany(p => p.InformationTos)
                            .HasForeignKey(d => d.ToId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Informations_Users1");
        }
    }
}
