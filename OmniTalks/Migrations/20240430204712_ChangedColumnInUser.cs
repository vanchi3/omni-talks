using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class ChangedColumnInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePhtotoUrl",
                table: "AspNetUsers",
                newName: "ProfilePhоtoUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07d6da17-1c98-466d-859a-0e0f9cc903e6", "AQAAAAIAAYagAAAAEDwkLHVqBRyqFQ3bp+0bPGNpnL7OXRrIEHI+nh/0U4qfeOGYDq4v0UgQkmC6HScduA==", "aea3317c-a12d-4b1d-8520-f3ce271e5e61" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePhоtoUrl",
                table: "AspNetUsers",
                newName: "ProfilePhtotoUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64483e51-10ce-4a39-bc93-0f37c9312f0d", "AQAAAAIAAYagAAAAEAD7IFZD5zU3fLluKor5rgbYLZ88y3EAjErjv9PptTMg+3uPVY5I1/IF5+8bawq10g==", "c5b177dd-8604-4dd6-8870-3106eb48e8c7" });
        }
    }
}
