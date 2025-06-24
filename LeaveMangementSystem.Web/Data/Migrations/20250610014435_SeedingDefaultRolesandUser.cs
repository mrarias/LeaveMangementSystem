using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveMangementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c9c3083-e299-4c58-a73e-1f5e3e873338", null, "Administrator", "Administrator" },
                    { "8ad1c185-af0b-4345-ac8b-f0d2c79c4a78", null, "Supervisor", "SUPERVISOR" },
                    { "b0370d96-bf08-46e4-a0a5-e4db75c32647", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eb8c6c79-d4c2-4255-bd07-9618293d109f", 0, "562bd825-f307-49f3-a1c9-e1bb56ed5091", "arias_melvin@yahoo.com.ph", true, false, null, "ARIAS_MELVIN@YAHOO.COM.PH", "ARIAS_MELVIN@YAHOO.COM.PH", "AQAAAAIAAYagAAAAECKGQe919Jo3j/ZRF8ImZ4k9grco3i3en3kK79/Xx3UgCps3Dy0LVFt2gRpfb4ON/A==", null, false, "1a28d378-cab0-4e07-858d-13399b60dd0b", false, "arias_melvin@yahoo.com.ph" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5c9c3083-e299-4c58-a73e-1f5e3e873338", "eb8c6c79-d4c2-4255-bd07-9618293d109f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ad1c185-af0b-4345-ac8b-f0d2c79c4a78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0370d96-bf08-46e4-a0a5-e4db75c32647");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5c9c3083-e299-4c58-a73e-1f5e3e873338", "eb8c6c79-d4c2-4255-bd07-9618293d109f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c9c3083-e299-4c58-a73e-1f5e3e873338");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8c6c79-d4c2-4255-bd07-9618293d109f");
        }
    }
}
