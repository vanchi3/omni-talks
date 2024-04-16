using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class AddPhtosToPOstAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhtotoUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "C:\\Users\\Ivana\\Desktop\\Dimplomen Proekt\\OmniTalks\\wwwroot\\images\\avatar-7.png");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ccff30f-0aec-43d7-b6ef-bf56d08d0591", "AQAAAAIAAYagAAAAEKIAEnOjr3w5XvMCAuKtH0d1CbvROyX3jv8ztCMY6xkRcZj0Kqa1HQISIQjdJb1DKQ==", "eee941b5-9663-450c-b6ca-bd9058cf93e0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ProfilePhtotoUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5e9b0cf-d5b1-4a9d-8798-fd012162ece4", "AQAAAAIAAYagAAAAEEgpXwBm1/tNAXxyPlFKLmmmyMbgAASDFBf2GZqnrzyNDLXCxg11CEQLHIrFdvuVSw==", "34859c20-7361-43c3-b7fa-e3d4fa5eaca2" });
        }
    }
}
