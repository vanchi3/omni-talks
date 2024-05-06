using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class RemoveDefaultCategoryId : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<Guid>(
				name: "CategoryId",
				table: "Posts",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldDefaultValue: new Guid("9af70a94-594a-4d80-8a4d-ae63b355f7e4"));
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<Guid>(
				name: "CategoryId",
				table: "Posts",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("9af70a94-594a-4d80-8a4d-ae63b355f7e4"),
				oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
		}
	}
}
