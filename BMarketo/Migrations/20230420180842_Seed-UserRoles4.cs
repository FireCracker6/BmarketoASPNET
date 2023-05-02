using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMarketo.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRoles4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "IdentityRole<string>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<string>", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad75c3fe-5a85-46aa-83e6-2dadc223172c", null, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "991de19b-1b9c-4cdc-a481-d9233d204e6f", 0, null, "881ebb09-e37b-4d02-8db4-cf292724d7f0", "administrator@domain.com", false, " ", null, " ", false, null, null, null, "AQAAAAIAAYagAAAAELtlQTqfl9zfFgFc/uNnE5E5HiDOv2p8sx+crnocLB0me+N/KH9rscPUsA8kOBC3nA==", null, false, "ee3dc969-4cfa-4317-9602-19846705ec7e", false, "admin" });

            migrationBuilder.InsertData(
                table: "IdentityRole<string>",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad75c3fe-5a85-46aa-83e6-2dadc223172c", null, "admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole<string>");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad75c3fe-5a85-46aa-83e6-2dadc223172c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "991de19b-1b9c-4cdc-a481-d9233d204e6f");

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
    }
}
