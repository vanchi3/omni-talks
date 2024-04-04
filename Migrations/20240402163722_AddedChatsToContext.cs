using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class AddedChatsToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_RecieverUserId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_SenderUserId",
                table: "Chat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                table: "Chat");

            migrationBuilder.RenameTable(
                name: "Chat",
                newName: "Chats");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_SenderUserId",
                table: "Chats",
                newName: "IX_Chats_SenderUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_RecieverUserId",
                table: "Chats",
                newName: "IX_Chats_RecieverUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_RecieverUserId",
                table: "Chats",
                column: "RecieverUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_SenderUserId",
                table: "Chats",
                column: "SenderUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_RecieverUserId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_SenderUserId",
                table: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Chat");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_SenderUserId",
                table: "Chat",
                newName: "IX_Chat_SenderUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_RecieverUserId",
                table: "Chat",
                newName: "IX_Chat_RecieverUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                table: "Chat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_RecieverUserId",
                table: "Chat",
                column: "RecieverUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_SenderUserId",
                table: "Chat",
                column: "SenderUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
