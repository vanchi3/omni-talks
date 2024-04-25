using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class FollowNamesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_UserId",
                table: "Follows");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Follows",
                newName: "FollowedId");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_UserId",
                table: "Follows",
                newName: "IX_Follows_FollowedId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64483e51-10ce-4a39-bc93-0f37c9312f0d", "AQAAAAIAAYagAAAAEAD7IFZD5zU3fLluKor5rgbYLZ88y3EAjErjv9PptTMg+3uPVY5I1/IF5+8bawq10g==", "c5b177dd-8604-4dd6-8870-3106eb48e8c7" });

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowedId",
                table: "Follows",
                column: "FollowedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowedId",
                table: "Follows");

            migrationBuilder.RenameColumn(
                name: "FollowedId",
                table: "Follows",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_FollowedId",
                table: "Follows",
                newName: "IX_Follows_UserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99126af6-f2c4-42e6-9184-12d4fc26455f", "AQAAAAIAAYagAAAAEJ23zOPIZNynTli7lj0zpGwtRleVHW6wg0DwmGwlCKY8m9KGYshpEPWmttiqfrLdNg==", "4822551d-ddda-4955-b8ad-c726463648c2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_UserId",
                table: "Follows",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
