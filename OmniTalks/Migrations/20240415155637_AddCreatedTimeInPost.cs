using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedTimeInPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5e9b0cf-d5b1-4a9d-8798-fd012162ece4", "AQAAAAIAAYagAAAAEEgpXwBm1/tNAXxyPlFKLmmmyMbgAASDFBf2GZqnrzyNDLXCxg11CEQLHIrFdvuVSw==", "34859c20-7361-43c3-b7fa-e3d4fa5eaca2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad266228-ff55-441f-8281-ade9522e8e32", "AQAAAAIAAYagAAAAEPAKxsKbuliVuabpdJIg0sAq5YI+6fpFtwRtjvgO/yX5zTCaGiSQWToHxRV/1ZpadQ==", "8931d00b-b725-4196-b265-fe2fc8b52884" });
        }
    }
}
