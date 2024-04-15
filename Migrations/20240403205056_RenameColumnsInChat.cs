using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class RenameColumnsInChat : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Chats_AspNetUsers_RecieverUserId",
				table: "Chats");

			migrationBuilder.DropForeignKey(
				name: "FK_Chats_AspNetUsers_SenderUserId",
				table: "Chats");

			migrationBuilder.RenameColumn(
				name: "SenderUserId",
				table: "Chats",
				newName: "User2Id");

			migrationBuilder.RenameColumn(
				name: "RecieverUserId",
				table: "Chats",
				newName: "User1Id");

			migrationBuilder.RenameIndex(
				name: "IX_Chats_SenderUserId",
				table: "Chats",
				newName: "IX_Chats_User2Id");

			migrationBuilder.RenameIndex(
				name: "IX_Chats_RecieverUserId",
				table: "Chats",
				newName: "IX_Chats_User1Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Chats_AspNetUsers_User1Id",
				table: "Chats",
				column: "User1Id",
				principalTable: "AspNetUsers",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Chats_AspNetUsers_User2Id",
				table: "Chats",
				column: "User2Id",
				principalTable: "AspNetUsers",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Chats_AspNetUsers_User1Id",
				table: "Chats");

			migrationBuilder.DropForeignKey(
				name: "FK_Chats_AspNetUsers_User2Id",
				table: "Chats");

			migrationBuilder.RenameColumn(
				name: "User2Id",
				table: "Chats",
				newName: "SenderUserId");

			migrationBuilder.RenameColumn(
				name: "User1Id",
				table: "Chats",
				newName: "RecieverUserId");

			migrationBuilder.RenameIndex(
				name: "IX_Chats_User2Id",
				table: "Chats",
				newName: "IX_Chats_SenderUserId");

			migrationBuilder.RenameIndex(
				name: "IX_Chats_User1Id",
				table: "Chats",
				newName: "IX_Chats_RecieverUserId");

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
	}
}
