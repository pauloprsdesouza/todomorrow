using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.Categories;

namespace Todomorrow.Infrastructure.Database.DataModel.Categories
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            _ = builder.ToTable("Category");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            _ = builder.HasIndex(x => x.Name);

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);

            _ = builder.HasMany(x => x.Subcategories).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
