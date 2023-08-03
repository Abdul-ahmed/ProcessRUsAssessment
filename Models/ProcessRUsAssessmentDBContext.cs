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

        //public DbSet<Country> Countries { get; set; }
        // public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleSeeder());
            modelBuilder.ApplyConfiguration(new AdminSeeder());
        //     modelBuilder.ApplyConfiguration(new HotelSeeder());
        }
    }
}
