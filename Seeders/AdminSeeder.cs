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
            builder.HasData(
                new User
                {
                    Email = "admin@processrus.com",
                    PasswordHash = "admin.password"
                });
        }
    }
}
