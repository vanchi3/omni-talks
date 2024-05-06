using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OmniTalks.Data.Configuraton
{
	public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
	{
		/// <summary>
		/// Adds default user roles to builder
		/// </summary>
		public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
		{
			builder.HasData(CreateUserRoles());
		}

		/// <summary>
		/// Creates the default user roles
		/// </summary>
		private static List<IdentityUserRole<Guid>> CreateUserRoles()
		{
			var userRoles = new List<IdentityUserRole<Guid>>();

			var userRole = new IdentityUserRole<Guid>()
			{
				RoleId = new Guid("ae27e064-4c1d-4082-a81b-848ee36c08a4"),
				UserId = new Guid("6171a065-a985-43f1-ba4c-0703775e2dc4"),
			};
			userRoles.Add(userRole);

			return userRoles;
		}
	}
}
