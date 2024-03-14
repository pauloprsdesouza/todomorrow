using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todomorrow.Domain.Users;

namespace Todomorrow.Infrastructure.Database.DataModel.Users
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            _ = builder.ToTable("User");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Id);

            _ = builder.Property(x => x.Email);

            _ = builder.HasIndex(x => x.Email);

            _ = builder.Property(x => x.CreatedAt).IsRequired();

            _ = builder.Property(x => x.UpdatedAt).HasDefaultValue(null);

            _ = builder.HasMany(x => x.Followers).WithOne(x => x.Follower).HasForeignKey(x => x.FollowerId);

            _ = builder.HasMany(x => x.Followees).WithOne(x => x.Followee).HasForeignKey(x => x.FolloweeId);

            _ = builder.HasMany(x => x.Organizations).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            _ = builder.HasMany(x => x.SoftSkills).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
