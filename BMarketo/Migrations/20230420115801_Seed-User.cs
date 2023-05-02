using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMarketo.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "083bd38b-8fe2-4f2f-b6b1-729dd63a51c8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8236f279-1eaf-4daa-9874-d13c90bdda52", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d346d1ec-0be2-4d99-974c-41cde323cd6c", 0, null, "409bf1c2-6368-4d76-ad62-1c17cfd90fb8", null, false, "System", null, "Administrator", false, null, null, null, "AQAAAAIAAYagAAAAECqZyw850hOQaSZBDs41j99PjRapMXFCHdiBfr2V4l0HP7EGHyO9XvFLgQRfqu133g==", null, false, "b3471b87-85e9-46dc-8cd3-9107c02e4f7d", false, "administrator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8236f279-1eaf-4daa-9874-d13c90bdda52");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d346d1ec-0be2-4d99-974c-41cde323cd6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "083bd38b-8fe2-4f2f-b6b1-729dd63a51c8", null, "System Administrator", "SYSTEM ADMINISTRATOR" });
        }
    }
}
