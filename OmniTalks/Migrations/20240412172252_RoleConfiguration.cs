using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OmniTalks.Migrations
{
	/// <inheritdoc />
	public partial class RoleConfiguration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[,]
				{
					{ new Guid("ae27e064-4c1d-4082-a81b-848ee36c08a4"), null, "Admin", null },
					{ new Guid("b9c967a1-c2a1-4858-8229-3a80e3b9a57a"), null, "User", null }
				});

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[,]
				{
					{ new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"), 0, "012a435a-40b2-4f9a-8d3e-96f79d7fe31f", "admin@mail.com", false, "admin@mail.com", "admin@mail.com", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEKBreFjgW9/NvQv8i64FhWqiuKCCjqyIK0J45vhWOkMjiW1qER37lne4dOBAmfA4eA==", null, false, "eddbe248-3f1f-4dd2-a24f-b715a3687153", false, "admin@mail.com" },
					{ new Guid("82464ad1-1fe1-462a-9f06-a05cd205cf5e"), 0, "e40e69cb-705d-4922-81eb-256d8b73cee7", "user@mail.com", false, "user@mail.com", "user@mail.com", false, null, "user@mail.com", "user@mail.com", "AQAAAAIAAYagAAAAEDLrN/XEczacISyL8b7Ma8ptjkoEIpl2GuKR7X3kRrYkQf+MUH0bwp9r1oUQxPKTDw==", null, false, "2c601b63-f67c-40c8-9f34-37c8e1379252", false, "user@mail.com" }
				});

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[,]
				{
					{ new Guid("ae27e064-4c1d-4082-a81b-848ee36c08a4"), new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4") },
					{ new Guid("b9c967a1-c2a1-4858-8229-3a80e3b9a57a"), new Guid("82464ad1-1fe1-462a-9f06-a05cd205cf5e") }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { new Guid("ae27e064-4c1d-4082-a81b-848ee36c08a4"), new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4") });

			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { new Guid("b9c967a1-c2a1-4858-8229-3a80e3b9a57a"), new Guid("82464ad1-1fe1-462a-9f06-a05cd205cf5e") });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: new Guid("ae27e064-4c1d-4082-a81b-848ee36c08a4"));

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: new Guid("b9c967a1-c2a1-4858-8229-3a80e3b9a57a"));

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"));

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("82464ad1-1fe1-462a-9f06-a05cd205cf5e"));
		}
	}
}
