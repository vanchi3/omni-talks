using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class AddedMessagesToChat : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<Guid>(
				name: "ChatId",
				table: "Messages",
				type: "uniqueidentifier",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Messages_ChatId",
				table: "Messages",
				column: "ChatId");

			migrationBuilder.AddForeignKey(
				name: "FK_Messages_Chats_ChatId",
				table: "Messages",
				column: "ChatId",
				principalTable: "Chats",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Messages_Chats_ChatId",
				table: "Messages");

			migrationBuilder.DropIndex(
				name: "IX_Messages_ChatId",
				table: "Messages");

			migrationBuilder.DropColumn(
				name: "ChatId",
				table: "Messages");
		}
	}
}
