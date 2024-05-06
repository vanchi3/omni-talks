using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniTalks.Models.Domein;

namespace OmniTalks.Data.Configuraton
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		/// <summary>
		/// Adds default users to builder
		/// </summary>
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(CreateUsers());
		}

		/// <summary>
		/// Creates the default users
		/// </summary>
		private static List<User> CreateUsers()
		{
			var users = new List<User>();
			var hasher = new PasswordHasher<User>();



			string email = "admin@mail.com";
			var user = new User()
			{
				Id = new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
				FirstName = email,
				LastName = email,
				UserName = email,
				NormalizedUserName = email,
				Email = email,
				NormalizedEmail = email
			};

			user.PasswordHash = hasher.HashPassword(user, "admin123");
			user.SecurityStamp = Guid.NewGuid().ToString();
			users.Add(user);

			return users;
		}
	}
}
