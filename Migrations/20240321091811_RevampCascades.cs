using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class RevampCascades : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Comments_AspNetUsers_UserId",
				table: "Comments");

			migrationBuilder.DropForeignKey(
				name: "FK_Comments_Posts_PostId",
				table: "Comments");

			migrationBuilder.DropForeignKey(
				name: "FK_CommentsLikes_AspNetUsers_UserId",
				table: "CommentsLikes");

			migrationBuilder.DropForeignKey(
				name: "FK_CommentsLikes_Comments_CommentId",
				table: "CommentsLikes");

			migrationBuilder.DropForeignKey(
				name: "FK_Posts_AspNetUsers_UserId",
				table: "Posts");

			migrationBuilder.DropForeignKey(
				name: "FK_PostsLikes_Posts_PostId",
				table: "PostsLikes");

			migrationBuilder.AddForeignKey(
				name: "FK_Comments_AspNetUsers_UserId",
				table: "Comments",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Comments_Posts_PostId",
				table: "Comments",
				column: "PostId",
				principalTable: "Posts",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_CommentsLikes_AspNetUsers_UserId",
				table: "CommentsLikes",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_CommentsLikes_Comments_CommentId",
				table: "CommentsLikes",
				column: "CommentId",
				principalTable: "Comments",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Posts_AspNetUsers_UserId",
				table: "Posts",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_PostsLikes_Posts_PostId",
				table: "PostsLikes",
				column: "PostId",
				principalTable: "Posts",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Comments_AspNetUsers_UserId",
				table: "Comments");

			migrationBuilder.DropForeignKey(
				name: "FK_Comments_Posts_PostId",
				table: "Comments");

			migrationBuilder.DropForeignKey(
				name: "FK_CommentsLikes_AspNetUsers_UserId",
				table: "CommentsLikes");

			migrationBuilder.DropForeignKey(
				name: "FK_CommentsLikes_Comments_CommentId",
				table: "CommentsLikes");

			migrationBuilder.DropForeignKey(
				name: "FK_Posts_AspNetUsers_UserId",
				table: "Posts");

			migrationBuilder.DropForeignKey(
				name: "FK_PostsLikes_Posts_PostId",
				table: "PostsLikes");

			migrationBuilder.AddForeignKey(
				name: "FK_Comments_AspNetUsers_UserId",
				table: "Comments",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Comments_Posts_PostId",
				table: "Comments",
				column: "PostId",
				principalTable: "Posts",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_CommentsLikes_AspNetUsers_UserId",
				table: "CommentsLikes",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_CommentsLikes_Comments_CommentId",
				table: "CommentsLikes",
				column: "CommentId",
				principalTable: "Comments",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Posts_AspNetUsers_UserId",
				table: "Posts",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_PostsLikes_Posts_PostId",
				table: "PostsLikes",
				column: "PostId",
				principalTable: "Posts",
				principalColumn: "Id");
		}
	}
}
