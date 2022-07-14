using Entity.Concretes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFrameworks.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.Property(e => e.Description).HasMaxLength(200);

            entity.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
