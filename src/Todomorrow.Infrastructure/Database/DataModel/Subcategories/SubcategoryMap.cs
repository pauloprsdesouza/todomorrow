using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.Subcategories;

namespace Todomorrow.Infrastructure.Database.DataModel.Subcategories
{
    public class SubcategoryMap : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            _ = builder.ToTable("Subcategory");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            _ = builder.HasIndex(x => x.Name);

            _ = builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            _ = builder.Property(x => x.CategoryId).IsRequired();

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);

            _ = builder.HasMany(x => x.SoftSkills).WithOne(x => x.Subcategory).HasForeignKey(x => x.SubcategoryId);
        }
    }
}