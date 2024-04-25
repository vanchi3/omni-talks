using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFollowNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Following_AspNetUsers_FollowerId",
                table: "Following");

            migrationBuilder.DropForeignKey(
                name: "FK_Following_AspNetUsers_UserId",
                table: "Following");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Following",
                table: "Following");

            migrationBuilder.RenameTable(
                name: "Following",
                newName: "Follows");

            migrationBuilder.RenameIndex(
                name: "IX_Following_UserId",
                table: "Follows",
                newName: "IX_Follows_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Following_FollowerId",
                table: "Follows",
                newName: "IX_Follows_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follows",
                table: "Follows",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99126af6-f2c4-42e6-9184-12d4fc26455f", "AQAAAAIAAYagAAAAEJ23zOPIZNynTli7lj0zpGwtRleVHW6wg0DwmGwlCKY8m9KGYshpEPWmttiqfrLdNg==", "4822551d-ddda-4955-b8ad-c726463648c2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowerId",
                table: "Follows",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_UserId",
                table: "Follows",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowerId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_UserId",
                table: "Follows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follows",
                table: "Follows");

            migrationBuilder.RenameTable(
                name: "Follows",
                newName: "Following");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_UserId",
                table: "Following",
                newName: "IX_Following_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_FollowerId",
                table: "Following",
                newName: "IX_Following_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Following",
                table: "Following",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1df813c-1aef-4148-8105-e517f5f7ea9b", "AQAAAAIAAYagAAAAEL2kiqWmXkhsA9ayzGPiakNGRK9sooKL/9zCZOvh2tUz/G2NwcJngT5geHqpVy3Lpw==", "6228a960-67f4-444e-ae0f-2491d84203c7" });

            migrationBuilder.AddForeignKey(
                name: "FK_Following_AspNetUsers_FollowerId",
                table: "Following",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Following_AspNetUsers_UserId",
                table: "Following",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
