using System;
using System.Collections.Generic;
using DataAccess.Concretes.EntityFrameworks.Mappings;
using Entity.Concretes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Concretes.EntityFrameworks
{
    public partial class TaskManagementContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-R2TQ29K ;Database=TaskManagement; Trusted_Connection=True;");
            }
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Information> Informations { get; set; } = null!;
        public virtual DbSet<Password> Passwords { get; set; } = null!;
        public virtual DbSet<TaskDetail> TaskDetails { get; set; } = null!;
        public virtual DbSet<ToDo> ToDos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryMapping());
            modelBuilder.ApplyConfiguration<Information>(new InformationMapping());
            modelBuilder.ApplyConfiguration<Password>(new PasswordMapping());
            modelBuilder.ApplyConfiguration<TaskDetail>(new TaskDetailMapping());
            modelBuilder.ApplyConfiguration<ToDo>(new ToDoMapping());
            modelBuilder.ApplyConfiguration<User>(new UserMapping());
        }
    }
}
