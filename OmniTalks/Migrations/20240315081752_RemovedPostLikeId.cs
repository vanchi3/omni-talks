using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class RemovedPostLikeId : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_PostsLikes",
				table: "PostsLikes");

			migrationBuilder.DropIndex(
				name: "IX_PostsLikes_UserId",
				table: "PostsLikes");

			migrationBuilder.DropColumn(
				name: "Id",
				table: "PostsLikes");

			migrationBuilder.AddPrimaryKey(
				name: "PK_PostsLikes",
				table: "PostsLikes",
				columns: new[] { "UserId", "PostId" });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_PostsLikes",
				table: "PostsLikes");

			migrationBuilder.AddColumn<Guid>(
				name: "Id",
				table: "PostsLikes",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AddPrimaryKey(
				name: "PK_PostsLikes",
				table: "PostsLikes",
				column: "Id");

			migrationBuilder.CreateIndex(
				name: "IX_PostsLikes_UserId",
				table: "PostsLikes",
				column: "UserId");
		}
	}
}
