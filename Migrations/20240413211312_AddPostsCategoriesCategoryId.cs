using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class AddPostsCategoriesCategoryId : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
				values: new object[] { "1dabfa13-097c-481f-9d33-0dd7af3ba154", "AQAAAAIAAYagAAAAEDPASE8yN0MBWdQ/nJgL7r/aMW35M9Sk1mjgnQnNVhPKIqRIDByMTAuRIyjAPfmkCw==", "8ab60b5c-688c-4a57-9b79-b8870ede4a6c" });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
				values: new object[] { "e0784618-e55d-42bb-8417-902185d07417", "AQAAAAIAAYagAAAAELSHGwRGrn7i/nXjBj1lY0OS572duHr8RG/ImW0ZQuHsD9OpwgKBG4gB6RDUzcjXdA==", "402d0c34-d864-4a19-a73c-8f3651035a01" });
		}
	}
}
