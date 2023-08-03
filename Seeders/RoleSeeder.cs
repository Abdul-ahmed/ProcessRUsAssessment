using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProcessRUsAssessment.Seeders
{
    public class RoleSeeder : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "BackOffice",
                    NormalizedName = "BACK OFFICE"
                },
                new IdentityRole
                {
                    Name = "FrontOffice",
                    NormalizedName = "FRONT OFFICE"
                });
        }
    }
}
