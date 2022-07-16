using Entity.Concretes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFrameworks.Mappings
{
    public class TaskDetailMapping : IEntityTypeConfiguration<TaskDetail>
    {
        public void Configure(EntityTypeBuilder<TaskDetail> entity)
        {
            entity.HasKey(e => e.TaskDetailID);

            entity.Property(e => e.TaskDetailID).HasColumnName("TaskDetailID");

            entity.Property(e => e.CloseDate).HasColumnType("datetime");

            entity.Property(e => e.FromId).HasColumnName("FromID");

            entity.Property(e => e.OpenDate).HasColumnType("datetime");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.ToDo)
                .WithMany(p => p.TaskDetails)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskDetails_Tasks");


            entity.HasOne(d => d.User)
                .WithMany(p => p.TaskDetailFroms)
                .HasForeignKey(d => d.FromId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskDetails_Users");
        }
    }
}
