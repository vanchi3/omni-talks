using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class AddBioToCategory : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "Bio",
				table: "Categories",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
				values: new object[] { "ad266228-ff55-441f-8281-ade9522e8e32", "AQAAAAIAAYagAAAAEPAKxsKbuliVuabpdJIg0sAq5YI+6fpFtwRtjvgO/yX5zTCaGiSQWToHxRV/1ZpadQ==", "8931d00b-b725-4196-b265-fe2fc8b52884" });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Bio",
				table: "Categories");

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
				values: new object[] { "1dabfa13-097c-481f-9d33-0dd7af3ba154", "AQAAAAIAAYagAAAAEDPASE8yN0MBWdQ/nJgL7r/aMW35M9Sk1mjgnQnNVhPKIqRIDByMTAuRIyjAPfmkCw==", "8ab60b5c-688c-4a57-9b79-b8870ede4a6c" });
		}
	}
}
