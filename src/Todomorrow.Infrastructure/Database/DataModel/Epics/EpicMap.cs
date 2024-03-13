using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.Epics;

namespace Todomorrow.Infrastructure.Database.DataModel.Epics
{
    public class EpicMap : IEntityTypeConfiguration<Epic>
    {
        public void Configure(EntityTypeBuilder<Epic> builder)
        {
            _ = builder.ToTable("Epic");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.ProjectId).IsRequired();

            _ = builder.Property(x => x.Name).IsRequired();

            _ = builder.Property(x => x.Description).IsRequired();

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);

            _ = builder.HasMany(x => x.WorkItems).WithOne(x => x.Epic).HasForeignKey(x => x.EpicId);
        }
    }
}
