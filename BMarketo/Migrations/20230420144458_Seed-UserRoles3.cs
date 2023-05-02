using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMarketo.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRoles3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b8aafdc8-0fad-4320-96c6-e8f1d751e782", null, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c90e9b7b-8b1d-485d-9661-f5fe5ec4ab72", 0, null, "7f23aec1-b634-452c-abf8-cc055d236a69", "administrator@domain.com", false, " ", null, " ", false, null, null, null, "AQAAAAIAAYagAAAAEKOhl8xfcf95a35fQlLnZdGN4yrtXyo8GKR4b+COpfzP2LYca6YEVsxJATg23xUmFw==", null, false, "950766c9-ac8f-4562-9120-48d6815c849a", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b8aafdc8-0fad-4320-96c6-e8f1d751e782", "c90e9b7b-8b1d-485d-9661-f5fe5ec4ab72" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b8aafdc8-0fad-4320-96c6-e8f1d751e782", "c90e9b7b-8b1d-485d-9661-f5fe5ec4ab72" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8aafdc8-0fad-4320-96c6-e8f1d751e782");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c90e9b7b-8b1d-485d-9661-f5fe5ec4ab72");

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
    }
}
