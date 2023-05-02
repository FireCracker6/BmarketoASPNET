using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMarketo.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRoles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ab999271-cf16-458f-9f19-af41a44ce9b9", "d747e06f-6c39-443d-bc1d-dd9cb73ee2a7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab999271-cf16-458f-9f19-af41a44ce9b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d747e06f-6c39-443d-bc1d-dd9cb73ee2a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "235a1c39-ce57-4f4b-8734-32590e591455", null, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a4c0694-a387-48be-a673-ce2feead25b0", 0, null, "7aa28f5f-0036-45a4-840c-d3545214316a", "administrator@domain.com", false, " ", null, " ", false, null, null, null, "AQAAAAIAAYagAAAAEELLNFCSIe4kUluJWKrsSycDYbkhdGZnAQonxsHxQ1iWyUB9QQO9b/IeRqWg2hVnqA==", null, false, "ffe6f431-4b71-4be9-9ed1-1d7c92dc9730", false, "administrator@domain.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "235a1c39-ce57-4f4b-8734-32590e591455", "2a4c0694-a387-48be-a673-ce2feead25b0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "235a1c39-ce57-4f4b-8734-32590e591455", "2a4c0694-a387-48be-a673-ce2feead25b0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "235a1c39-ce57-4f4b-8734-32590e591455");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a4c0694-a387-48be-a673-ce2feead25b0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab999271-cf16-458f-9f19-af41a44ce9b9", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d747e06f-6c39-443d-bc1d-dd9cb73ee2a7", 0, null, "fa104bf2-3e15-4ee3-909a-ed1f74c4cec7", "administrator@domain.com", false, " ", null, " ", false, null, null, null, "AQAAAAIAAYagAAAAEL/zKxWXN/o6piFOlxHwMi5Gc2MCPhz8KwBWvPQIlASJ4/gEnIfdXM/naNA/52aSIw==", null, false, "32ddf45c-8711-4867-ba03-6724f511fdd8", false, "administrator@domain.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ab999271-cf16-458f-9f19-af41a44ce9b9", "d747e06f-6c39-443d-bc1d-dd9cb73ee2a7" });
        }
    }
}
