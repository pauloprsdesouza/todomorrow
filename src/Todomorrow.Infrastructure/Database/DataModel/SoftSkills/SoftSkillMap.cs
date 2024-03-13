using Amazon.DynamoDBv2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using System;
using Todomorrow.Domain.ActionItems;
using Todomorrow.Domain.SoftSkills;
using Todomorrow.Domain.Users;

namespace Todomorrow.Infrastructure.Database.DataModel.SoftSkills
{
    public class SoftSkillMap : IEntityTypeConfiguration<SoftSkill>
    {
        public void Configure(EntityTypeBuilder<SoftSkill> builder)
        {
            _ = builder.ToTable("SoftSkill");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.Name).IsRequired();

            _ = builder.Property(x => x.Level).IsRequired();

            _ = builder.Property(x => x.SubcategoryId).IsRequired();

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);

            _ = builder.HasOne(x => x.Subcategory).WithMany(x => x.SoftSkills).HasForeignKey(x => x.SubcategoryId);

            _ = builder.HasMany(x => x.Users).WithMany(x => x.SoftSkills).UsingEntity("UserSkill",
                    l => l.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)),
                    r => r.HasOne(typeof(SoftSkill)).WithMany().HasForeignKey("SoftSkillId").HasPrincipalKey(nameof(SoftSkill.Id)),
                    j => j.HasKey("UserId", "SoftSkillId"));

            _ = builder.HasMany(x => x.ActionItems).WithMany(x => x.RequiredSoftSkills).UsingEntity("RequiredSoftSkill",
                    l => l.HasOne(typeof(ActionItem)).WithMany().HasForeignKey("ActionItemId").HasPrincipalKey(nameof(ActionItem.Id)),
                    r => r.HasOne(typeof(SoftSkill)).WithMany().HasForeignKey("SoftSkillId").HasPrincipalKey(nameof(SoftSkill.Id)),
                    j => j.HasKey("ActionItemId", "SoftSkillId"));
        }
    }
}
