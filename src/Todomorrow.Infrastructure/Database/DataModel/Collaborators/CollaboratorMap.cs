using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.Collaborators;

namespace Todomorrow.Infrastructure.Database.DataModel.Collaborators
{
    public class CollaboratorMap : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            _ = builder.ToTable("Collaborator");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.UserId).IsRequired();

            _ = builder.Property(x => x.OrganizationId).IsRequired();

            _ = builder.Property(x => x.AdmissionDate).IsRequired();

            _ = builder.Property(x => x.ResignationDate).HasDefaultValue(null);

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);
        }
    }
}
