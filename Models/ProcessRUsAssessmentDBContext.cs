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
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = "28c30205-0248-411f-8b00-9141a2ce0300",
            //    UserId = "fa13b0b2-2876-4759-91e3-50d43848b990"
            //});
        }
    }
}
