using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveMangementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8c6c79-d4c2-4255-bd07-9618293d109f",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89ba3fbb-f45f-419f-8c94-6d92a6060550", new DateOnly(1950, 12, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEIMFspge0lgGeFd5cbDtOROq1eDL4d4XEF4AcXRq8w1QX9RMxWB01UCGmVTxLzXfiA==", "d3ab6055-2a53-451b-915a-2ef9db469a0c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8c6c79-d4c2-4255-bd07-9618293d109f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "562bd825-f307-49f3-a1c9-e1bb56ed5091", "AQAAAAIAAYagAAAAECKGQe919Jo3j/ZRF8ImZ4k9grco3i3en3kK79/Xx3UgCps3Dy0LVFt2gRpfb4ON/A==", "1a28d378-cab0-4e07-858d-13399b60dd0b" });
        }
    }
}
