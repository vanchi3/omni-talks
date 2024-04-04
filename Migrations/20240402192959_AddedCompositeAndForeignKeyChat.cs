using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompositeAndForeignKeyChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_SenderUserId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Chats");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChatRecieverUserId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChatSenderUserId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                columns: new[] { "SenderUserId", "RecieverUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatSenderUserId_ChatRecieverUserId",
                table: "Messages",
                columns: new[] { "ChatSenderUserId", "ChatRecieverUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatSenderUserId_ChatRecieverUserId",
                table: "Messages",
                columns: new[] { "ChatSenderUserId", "ChatRecieverUserId" },
                principalTable: "Chats",
                principalColumns: new[] { "SenderUserId", "RecieverUserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatSenderUserId_ChatRecieverUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatSenderUserId_ChatRecieverUserId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "ChatRecieverUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ChatSenderUserId",
                table: "Messages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_SenderUserId",
                table: "Chats",
                column: "SenderUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");
        }
    }
}
