using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.Projects;

namespace Todomorrow.Infrastructure.Database.DataModel.Projects
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            _ = builder.ToTable("Project");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.OrganizationId).IsRequired();

            _ = builder.Property(x => x.Name).IsRequired();

            _ = builder.HasIndex(x => x.Name);
            
            _ = builder.Property(x => x.Description).IsRequired();

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);

            _ = builder.HasMany(x => x.Epics).WithOne(x => x.Project).HasForeignKey(x => x.ProjectId);
        }
    }
}
