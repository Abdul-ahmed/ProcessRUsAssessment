using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProcessRUsAssessment.Migrations
{
    /// <inheritdoc />
    public partial class AddedRoleToAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "859fe597-5b71-4c68-b62f-adefd8a077c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9269175b-c8a6-4af9-aef3-8b0d24e4b0d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4b25574-4a6e-4c73-90c1-d3bb0617e64d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ab6aeb6-32eb-4a1e-a6f7-8bcb1a3377f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56293a77-3081-427a-9798-692afc89029c", null, "Role", "BackOffice", "BACKOFFICE" },
                    { "79882c80-b44c-4019-84f7-4c092636cad6", null, "Role", "Admin", "ADMIN" },
                    { "9e376400-5805-4b60-bbc8-7ec7d7685a5a", null, "Role", "FrontOffice", "FRONTOFFICE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b4b25574-4a6e-4c73-90c1-d3bb0617e64d", "1ab6aeb6-32eb-4a1e-a6f7-8bcb1a3377f8" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cfa26e3f-a3b9-40b1-ab85-c160d6eb4dee", 0, "2f046042-87b6-4e41-8ead-5120bf27de35", "admin@processrus.com", false, true, null, "ADMIN@PROCESSRUS.COM", "ADMIN@PROCESSRUS.COM", "AQAAAAIAAYagAAAAEEnf+wwuoB7SgET5jH2FaPgq5+7jt7LGmwAFbZ+HzhXvPrEuedjhCWx+68FIZYv18Q==", null, false, "e60be303-49a7-4ee7-a7b1-7da89d1a6b1e", false, "admin@processrus.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56293a77-3081-427a-9798-692afc89029c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79882c80-b44c-4019-84f7-4c092636cad6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e376400-5805-4b60-bbc8-7ec7d7685a5a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b4b25574-4a6e-4c73-90c1-d3bb0617e64d", "1ab6aeb6-32eb-4a1e-a6f7-8bcb1a3377f8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfa26e3f-a3b9-40b1-ab85-c160d6eb4dee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "859fe597-5b71-4c68-b62f-adefd8a077c7", null, "Role", "FrontOffice", "FRONTOFFICE" },
                    { "9269175b-c8a6-4af9-aef3-8b0d24e4b0d8", null, "Role", "BackOffice", "BACKOFFICE" },
                    { "b4b25574-4a6e-4c73-90c1-d3bb0617e64d", null, "Role", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1ab6aeb6-32eb-4a1e-a6f7-8bcb1a3377f8", 0, "3928912c-e2fe-4274-aca6-32ad5bbe8122", "admin@processrus.com", false, true, null, "ADMIN@PROCESSRUS.COM", "ADMIN@PROCESSRUS.COM", "AQAAAAIAAYagAAAAEBi5RSOrDsPkcx/IpMdp5TTiTjy+F2Aqmhi7OdvJjxNfEHbMqC2kqEFpWOfERNjZ4A==", null, false, "f773dc1b-6b27-4448-9efe-af37eeba8043", false, "admin@processrus.com" });
        }
    }
}
