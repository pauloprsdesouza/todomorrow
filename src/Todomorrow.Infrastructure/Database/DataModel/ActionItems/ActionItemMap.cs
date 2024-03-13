using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.ActionItems;

namespace Todomorrow.Infrastructure.Database.DataModel.ActionItems
{
    public class ActionItemMap : IEntityTypeConfiguration<ActionItem>
    {
        public void Configure(EntityTypeBuilder<ActionItem> builder)
        {
            _ = builder.ToTable("ActionItem");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.WorkItemId);

            _ = builder.HasIndex(x => x.Name);

            _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            _ = builder.Property(x => x.Description).IsRequired();

            _ = builder.Property(x => x.DueDate).IsRequired();

            _ = builder.Property(x => x.StartedAt).HasDefaultValue(null);

            _ = builder.Property(x => x.CompletedAt).HasDefaultValue(null);

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);
        }
    }
}
