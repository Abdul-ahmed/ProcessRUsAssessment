using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessRUsAssessment.Models;
using System.Diagnostics.Metrics;

namespace ProcessRUsAssessment.Seeders
{
    public class AdminSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var admin = new User
            {
                Email = "admin@processrus.com",
                EmailConfirmed = false,
                UserName = "admin@processrus.com",
                NormalizedUserName = "ADMIN@PROCESSRUS.COM",
                NormalizedEmail = "ADMIN@PROCESSRUS.COM",
                LockoutEnabled = true
            };

            PasswordHasher<User> ph = new PasswordHasher<User>();
            admin.PasswordHash = ph.HashPassword(admin, "adminP@ssword1");

            builder.HasData(admin);
        }
    }
}
