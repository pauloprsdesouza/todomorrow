using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.WorkItems;

namespace Todomorrow.Infrastructure.Database.DataModel.WorkItems
{
    public class WorkItemMap : IEntityTypeConfiguration<WorkItem>
    {
        public void Configure(EntityTypeBuilder<WorkItem> builder)
        {
            _ = builder.ToTable("WorkItem");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.EpicId);

            _ = builder.Property(x => x.Name).IsRequired();

            _ = builder.Property(x => x.Description).IsRequired();

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);

            _ = builder.HasMany(x => x.ActionItems).WithOne(x => x.WorkItem).HasForeignKey(x => x.WorkItemId);
        }
    }
}
