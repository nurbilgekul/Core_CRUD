using Core_CRUD.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Core_CRUD.Infrastructure.EntityTypeConfigurations.Abstract
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).HasColumnType("datetime2").HasColumnName("CreateDate").IsRequired(true);
            builder.Property(x => x.UpdateDate).HasColumnType("datetime2").HasColumnName("UpdateDate").IsRequired(false); 
            builder.Property(x => x.DeleteDate).HasColumnType("datetime2").HasColumnName("DeleteDate").IsRequired(false);
            builder.Property(x => x.Status).HasColumnName("Status").IsRequired(true);
        }
    }
}
