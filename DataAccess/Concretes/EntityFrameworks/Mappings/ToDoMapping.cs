using Entity.Concretes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFrameworks.Mappings
{
    public class ToDoMapping : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> entity)
        {
            entity.HasKey(e => e.TaskId)
                    .HasName("PK_Tasks");

            entity.ToTable("ToDo");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.Property(e => e.Description).HasMaxLength(500);

            entity.Property(e => e.Subject).HasMaxLength(50);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.ToDos)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Categories");
        }
    }
}
