using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class UpdateCategories : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
				values: new object[] { "e0784618-e55d-42bb-8417-902185d07417", "AQAAAAIAAYagAAAAELSHGwRGrn7i/nXjBj1lY0OS572duHr8RG/ImW0ZQuHsD9OpwgKBG4gB6RDUzcjXdA==", "402d0c34-d864-4a19-a73c-8f3651035a01" });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
				values: new object[] { "bcc77336-108b-46fb-b5db-53b0689131ac", "AQAAAAIAAYagAAAAEDz5ErTZzC874BJg/VoebzcLNlKjvD60Z6bqQgWbseROMH6yUv2OL49/BwlVkiPtng==", "2b8db046-1ec1-4169-93c3-84a74f12a597" });
		}
	}
}
