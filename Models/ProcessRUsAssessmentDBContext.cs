using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcessRUsAssessment.Seeders;
using System.Diagnostics.Metrics;

namespace ProcessRUsAssessment.Models
{
    public class ProcessRUsAssessmentDBContext : IdentityDbContext<User>
    {
        public ProcessRUsAssessmentDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleSeeder());
            modelBuilder.ApplyConfiguration(new AdminSeeder());
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "b4b25574-4a6e-4c73-90c1-d3bb0617e64d",
                UserId = "1ab6aeb6-32eb-4a1e-a6f7-8bcb1a3377f8"
            });
        }
    }
}
