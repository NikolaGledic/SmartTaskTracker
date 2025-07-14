using Microsoft.EntityFrameworkCore;
using SmartTaskTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Infrastructure.Data
{
    public class SmartTaskTrackerDbContext : DbContext
    {
        public SmartTaskTrackerDbContext(DbContextOptions<SmartTaskTrackerDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ExternalIntegration> ExternalIntegrations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TeamUser>(b =>
            {
                b.HasKey(tu => new { tu.TeamId, tu.UserId });
                b.HasOne(tu => tu.Team)
                .WithMany(t => t.TeamUsers)
                .HasForeignKey(tu => tu.TeamId);
                b.HasOne(tu => tu.User)
                .WithMany(u => u.TeamUsers)
                .HasForeignKey(tu => tu.UserId);
            });

            modelBuilder.Entity<TaskItem>(b =>
            {
                b.Property(t => t.CreatedAt)
                .HasDefaultValueSql("SYSUTCDATETIME()");

                b.HasOne(t => t.Assignee)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssigneeId)
                .OnDelete(DeleteBehavior.SetNull);

                b.HasOne(t => t.Creator)
                .WithMany(u => u.CreatedTask)
                .HasForeignKey(t => t.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Comment>(b =>
            {
                b.Property(c => c.CreatedAt)
                .HasDefaultValueSql("SYSUTCDATETIME()");
                b.HasOne(c => c.Task)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskItemId);
                b.HasOne(c => c.Author)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.AuthorId);
            });
            modelBuilder.Entity<ExternalIntegration>(b =>
            {
                b.Property(e => e.LastFetched).IsRequired();
                b.Property(e => e.Payload).IsRequired();
            });

            
        }
    }
}
