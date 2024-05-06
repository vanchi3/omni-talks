using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class PostImgUrlNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d82c0d1-2fe6-4bf2-8603-8ed1492cf616", "AQAAAAIAAYagAAAAEBqgRU9jVkQKeGNpK3mcN9CoSId8CwqCBpgy2PTleJCrcQfsm5Jqq5TfqAqYg591fA==", "63f27caf-0fe0-4a2d-b63f-11bbaf47e944" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7e9f51a-0ef6-4204-b131-5c474d52b6b9", "AQAAAAIAAYagAAAAEL4JmMMESPtOCMfGu/yRyzdAfpb+n6Ryf0qj44yX48duhP8aUUcg1X71cnC3mub+Pw==", "afe27c44-969a-4acf-8882-c55fdab28ff6" });
        }
    }
}
