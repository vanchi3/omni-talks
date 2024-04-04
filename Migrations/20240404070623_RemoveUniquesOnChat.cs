using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniquesOnChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chats_User1Id",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_User2Id",
                table: "Chats");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User1Id",
                table: "Chats",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User2Id",
                table: "Chats",
                column: "User2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chats_User1Id",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_User2Id",
                table: "Chats");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User1Id",
                table: "Chats",
                column: "User1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User2Id",
                table: "Chats",
                column: "User2Id",
                unique: true);
        }
    }
}
