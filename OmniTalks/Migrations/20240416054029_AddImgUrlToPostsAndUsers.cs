using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class AddImgUrlToPostsAndUsers : Migration
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
                defaultValue: "/images/avatar-7.png");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7e9f51a-0ef6-4204-b131-5c474d52b6b9", "AQAAAAIAAYagAAAAEL4JmMMESPtOCMfGu/yRyzdAfpb+n6Ryf0qj44yX48duhP8aUUcg1X71cnC3mub+Pw==", "afe27c44-969a-4acf-8882-c55fdab28ff6" });
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
