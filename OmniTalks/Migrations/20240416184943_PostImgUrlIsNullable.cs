using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class PostImgUrlIsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7edcca99-1e33-45ad-b7bf-99ef7e12880e", "AQAAAAIAAYagAAAAEL0g9xhE4edd504jzqZVM3iciw7Jc/vcZDfwp70axkEBvC0FYBjUHjgDLiMKsEz7kA==", "e533e4ea-0c9e-4a31-9060-e7667ac7ee65" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d82c0d1-2fe6-4bf2-8603-8ed1492cf616", "AQAAAAIAAYagAAAAEBqgRU9jVkQKeGNpK3mcN9CoSId8CwqCBpgy2PTleJCrcQfsm5Jqq5TfqAqYg591fA==", "63f27caf-0fe0-4a2d-b63f-11bbaf47e944" });
        }
    }
}
