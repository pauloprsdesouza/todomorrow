using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.UserSkills;

namespace Todomorrow.Infrastructure.Database.DataModel.UserSkills
{
    public class UserSkillMap : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            _ = builder.ToTable("UserSkill");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.UserId).IsRequired();

            _ = builder.Property(x => x.SoftSkillId).IsRequired();

            _ = builder.Property(x => x.Level).IsRequired();

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);

        }
    }
}