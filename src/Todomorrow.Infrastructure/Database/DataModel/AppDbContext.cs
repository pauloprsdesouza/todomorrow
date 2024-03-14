using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Todomorrow.Domain.ActionItems;
using Todomorrow.Domain.Collaborators;
using Todomorrow.Domain.Epics;
using Todomorrow.Domain.Organizations;
using Todomorrow.Domain.Partners;
using Todomorrow.Domain.Projects;
using Todomorrow.Domain.SoftSkills;
using Todomorrow.Domain.UserFollowers;
using Todomorrow.Domain.Users;
using Todomorrow.Domain.UserSkills;
using Todomorrow.Domain.WorkItems;

namespace Todomorrow.Infrastructure.Database.DataModel
{
    public class AppDbContext : DbContext
    {
        private const string Schema = "todomorrow";

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.HasDefaultSchema(Schema);

            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<ActionItem> ActionItems { get; set; }
        public DbSet<Epic> Epics { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SoftSkill> SoftSkills { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<UserFollower> Followers { get; set; }
    }
}
