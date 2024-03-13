using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.Partners;

namespace Todomorrow.Infrastructure.Database.DataModel.Partners
{
    public class PartnerMap : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            _ = builder.ToTable("Partner");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.OrganizationId).IsRequired();

            _ = builder.Property(x => x.UserId).IsRequired();

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);

            _ = builder.HasOne(x => x.Organization).WithMany(x => x.Partners).HasForeignKey(x => x.OrganizationId);

            _ = builder.HasOne(x => x.User).WithMany(x => x.Partners).HasForeignKey(x => x.UserId);
        }
    }
}
