using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessRUsAssessment.Models;

namespace ProcessRUsAssessment.Seeders
{
    public class RoleSeeder : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Name = "BackOffice",
                    NormalizedName = "BACKOFFICE"
                },
                new Role
                {
                    Name = "FrontOffice",
                    NormalizedName = "FRONTOFFICE"
                });
        }
    }
}
