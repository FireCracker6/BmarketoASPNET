using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMarketo.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRoles5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f532b0f2-4449-4470-918c-fd16d9c471ee", null, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "182a4c7c-4b89-4c7a-92b6-565874d7c8a0", 0, null, "42735469-a399-4051-9999-b8c1d531bc1c", "administrator@domain.com", false, "Jack", null, "Russell", false, null, null, null, "AQAAAAIAAYagAAAAEE2nS9i4f3rc5h0crbyDWvsrTKQ3i/gHx3A8uA3Lz9RvahWhVgXIXxlPyW4BtFUSWg==", null, false, "eab46f48-3f45-4eaa-9032-604a720568d9", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f532b0f2-4449-4470-918c-fd16d9c471ee", "182a4c7c-4b89-4c7a-92b6-565874d7c8a0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f532b0f2-4449-4470-918c-fd16d9c471ee", "182a4c7c-4b89-4c7a-92b6-565874d7c8a0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f532b0f2-4449-4470-918c-fd16d9c471ee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "182a4c7c-4b89-4c7a-92b6-565874d7c8a0");

            migrationBuilder.CreateTable(
                name: "IdentityRole<string>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
