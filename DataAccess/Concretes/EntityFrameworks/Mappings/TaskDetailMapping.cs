using Entity.Concretes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFrameworks.Mappings
{
    public class TaskDetailMapping : IEntityTypeConfiguration<TaskDetail>
    {
        public void Configure(EntityTypeBuilder<TaskDetail> entity)
        {
            entity.HasKey(e => e.TaskId);

            entity.Property(e => e.CloseDate).HasColumnType("datetime");

            entity.Property(e => e.FromId).HasColumnName("FromID");

            entity.Property(e => e.OpenDate).HasColumnType("datetime");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.Property(e => e.ToId).HasColumnName("ToID");

            entity.HasOne(d => d.UserFrom)
                .WithMany(p => p.TaskDetailFroms)
                .HasForeignKey(d => d.FromId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskDetails_Users");

            entity.HasOne(d => d.UserTo)
                .WithMany(p => p.TaskDetailTos)
                .HasForeignKey(d => d.ToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskDetails_Users1");
        }
    }
}
