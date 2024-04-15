using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class AddCategoryIdToPosts : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var catGuid = "9af70a94-594a-4d80-8a4d-ae63b355f7e4";

			migrationBuilder.CreateTable(
				name: "Categories",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categories", x => x.Id);
				});

			migrationBuilder.Sql(
				"INSERT INTO Categories" +
				$" VALUES ('{catGuid}', 'TestName')");

			migrationBuilder.AddColumn<Guid>(
				name: "CategoryId",
				table: "Posts",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid(catGuid));

			migrationBuilder.CreateIndex(
				name: "IX_Posts_CategoryId",
				table: "Posts",
				column: "CategoryId");

			migrationBuilder.AddForeignKey(
				name: "FK_Posts_Categories_CategoryId",
				table: "Posts",
				column: "CategoryId",
				principalTable: "Categories",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Posts_Categories_CategoryId",
				table: "Posts");

			migrationBuilder.DropTable(
				name: "Categories");

			migrationBuilder.DropIndex(
				name: "IX_Posts_CategoryId",
				table: "Posts");

			migrationBuilder.DropColumn(
				name: "CategoryId",
				table: "Posts");
		}
	}
}
