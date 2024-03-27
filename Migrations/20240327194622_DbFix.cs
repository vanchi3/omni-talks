using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
    /// <inheritdoc />
    public partial class DbFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentsLikes",
                table: "CommentsLikes");

            migrationBuilder.DropIndex(
                name: "IX_CommentsLikes_UserId",
                table: "CommentsLikes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CommentsLikes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentsLikes",
                table: "CommentsLikes",
                columns: new[] { "UserId", "CommentId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentsLikes",
                table: "CommentsLikes");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CommentsLikes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentsLikes",
                table: "CommentsLikes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsLikes_UserId",
                table: "CommentsLikes",
                column: "UserId");
        }
    }
}
