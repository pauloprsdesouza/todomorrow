using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.Organizations;

namespace Todomorrow.Infrastructure.Database.DataModel.Organizations
{
    public class OrganizationMap : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            _ = builder.ToTable("Organization");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.Name).IsRequired();

            _ = builder.HasIndex(x => x.Name);

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);

            _ = builder.HasMany(x => x.Projects).WithOne(x => x.Organization).HasForeignKey(x => x.OrganizationId);

            _ = builder.HasMany(x => x.Collaborators).WithOne(x => x.Organization).HasForeignKey(x => x.OrganizationId);
        }
    }
}
