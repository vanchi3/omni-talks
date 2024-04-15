using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class RemoveUserRole : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { new Guid("b9c967a1-c2a1-4858-8229-3a80e3b9a57a"), new Guid("82464ad1-1fe1-462a-9f06-a05cd205cf5e") });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: new Guid("b9c967a1-c2a1-4858-8229-3a80e3b9a57a"));

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("82464ad1-1fe1-462a-9f06-a05cd205cf5e"));

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
				values: new object[] { "bcc77336-108b-46fb-b5db-53b0689131ac", "AQAAAAIAAYagAAAAEDz5ErTZzC874BJg/VoebzcLNlKjvD60Z6bqQgWbseROMH6yUv2OL49/BwlVkiPtng==", "2b8db046-1ec1-4169-93c3-84a74f12a597" });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[] { new Guid("b9c967a1-c2a1-4858-8229-3a80e3b9a57a"), null, "User", null });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
				values: new object[] { "012a435a-40b2-4f9a-8d3e-96f79d7fe31f", "AQAAAAIAAYagAAAAEKBreFjgW9/NvQv8i64FhWqiuKCCjqyIK0J45vhWOkMjiW1qER37lne4dOBAmfA4eA==", "eddbe248-3f1f-4dd2-a24f-b715a3687153" });

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { new Guid("82464ad1-1fe1-462a-9f06-a05cd205cf5e"), 0, "e40e69cb-705d-4922-81eb-256d8b73cee7", "user@mail.com", false, "user@mail.com", "user@mail.com", false, null, "user@mail.com", "user@mail.com", "AQAAAAIAAYagAAAAEDLrN/XEczacISyL8b7Ma8ptjkoEIpl2GuKR7X3kRrYkQf+MUH0bwp9r1oUQxPKTDw==", null, false, "2c601b63-f67c-40c8-9f34-37c8e1379252", false, "user@mail.com" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { new Guid("b9c967a1-c2a1-4858-8229-3a80e3b9a57a"), new Guid("82464ad1-1fe1-462a-9f06-a05cd205cf5e") });
		}
	}
}
