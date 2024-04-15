using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class AddConnectiontoFolllowsInUsers : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Following",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					IsFollowing = table.Column<bool>(type: "bit", nullable: false),
					UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					FollowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Following", x => x.Id);
					table.ForeignKey(
						name: "FK_Following_AspNetUsers_FollowerId",
						column: x => x.FollowerId,
						principalTable: "AspNetUsers",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_Following_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id");
				});

			migrationBuilder.CreateIndex(
				name: "IX_Following_FollowerId",
				table: "Following",
				column: "FollowerId");

			migrationBuilder.CreateIndex(
				name: "IX_Following_UserId",
				table: "Following",
				column: "UserId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Following");
		}
	}
}
