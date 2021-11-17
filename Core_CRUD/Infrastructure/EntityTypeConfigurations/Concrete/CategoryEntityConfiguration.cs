using Core_CRUD.Infrastructure.EntityTypeConfigurations.Abstract;
using Core_CRUD.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CRUD.Infrastructure.EntityTypeConfigurations.Concrete
{
    public class CategoryEntityConfiguration:BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(300).IsRequired(true);
            base.Configure(builder);
        }
    }
}
