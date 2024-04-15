using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class ChatTable : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Messages_AspNetUsers_RecieverUserId",
				table: "Messages");

			migrationBuilder.DropForeignKey(
				name: "FK_Messages_AspNetUsers_SenderUserId",
				table: "Messages");

			migrationBuilder.DropIndex(
				name: "IX_Messages_RecieverUserId",
				table: "Messages");

			migrationBuilder.DropIndex(
				name: "IX_Messages_SenderUserId",
				table: "Messages");

			migrationBuilder.DropColumn(
				name: "RecieverUserId",
				table: "Messages");

			migrationBuilder.DropColumn(
				name: "SenderUserId",
				table: "Messages");

			migrationBuilder.AddColumn<Guid>(
				name: "ChatId",
				table: "Messages",
				type: "uniqueidentifier",
				nullable: true);

			migrationBuilder.AddColumn<DateTime>(
				name: "SentTime",
				table: "Messages",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.CreateTable(
				name: "Chat",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					RecieverUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					SenderUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Chat", x => x.Id);
					table.ForeignKey(
						name: "FK_Chat_AspNetUsers_RecieverUserId",
						column: x => x.RecieverUserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_Chat_AspNetUsers_SenderUserId",
						column: x => x.SenderUserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id");
				});

			migrationBuilder.CreateIndex(
				name: "IX_Messages_ChatId",
				table: "Messages",
				column: "ChatId");

			migrationBuilder.CreateIndex(
				name: "IX_Chat_RecieverUserId",
				table: "Chat",
				column: "RecieverUserId");

			migrationBuilder.CreateIndex(
				name: "IX_Chat_SenderUserId",
				table: "Chat",
				column: "SenderUserId");

			migrationBuilder.AddForeignKey(
				name: "FK_Messages_Chat_ChatId",
				table: "Messages",
				column: "ChatId",
				principalTable: "Chat",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Messages_Chat_ChatId",
				table: "Messages");

			migrationBuilder.DropTable(
				name: "Chat");

			migrationBuilder.DropIndex(
				name: "IX_Messages_ChatId",
				table: "Messages");

			migrationBuilder.DropColumn(
				name: "ChatId",
				table: "Messages");

			migrationBuilder.DropColumn(
				name: "SentTime",
				table: "Messages");

			migrationBuilder.AddColumn<Guid>(
				name: "RecieverUserId",
				table: "Messages",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AddColumn<Guid>(
				name: "SenderUserId",
				table: "Messages",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.CreateIndex(
				name: "IX_Messages_RecieverUserId",
				table: "Messages",
				column: "RecieverUserId");

			migrationBuilder.CreateIndex(
				name: "IX_Messages_SenderUserId",
				table: "Messages",
				column: "SenderUserId");

			migrationBuilder.AddForeignKey(
				name: "FK_Messages_AspNetUsers_RecieverUserId",
				table: "Messages",
				column: "RecieverUserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Messages_AspNetUsers_SenderUserId",
				table: "Messages",
				column: "SenderUserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id");
		}
	}
}
