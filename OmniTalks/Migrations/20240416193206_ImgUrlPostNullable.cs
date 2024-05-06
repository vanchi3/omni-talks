using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class ImgUrlPostNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1df813c-1aef-4148-8105-e517f5f7ea9b", "AQAAAAIAAYagAAAAEL2kiqWmXkhsA9ayzGPiakNGRK9sooKL/9zCZOvh2tUz/G2NwcJngT5geHqpVy3Lpw==", "6228a960-67f4-444e-ae0f-2491d84203c7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7edcca99-1e33-45ad-b7bf-99ef7e12880e", "AQAAAAIAAYagAAAAEL0g9xhE4edd504jzqZVM3iciw7Jc/vcZDfwp70axkEBvC0FYBjUHjgDLiMKsEz7kA==", "e533e4ea-0c9e-4a31-9060-e7667ac7ee65" });
        }
    }
}
