using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OmniTalks.Data.Configuraton
{
	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
	{

		public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
		{
			builder.HasData(CreateRoles());
		}

		public static List<IdentityRole<Guid>> CreateRoles()
		{
			var roles = new List<IdentityRole<Guid>>();
			var role = new IdentityRole<Guid>()
			{
				Id = new Guid("ae27e064-4c1d-4082-a81b-848ee36c08a4"),
				Name = "Admin"
			};

			roles.Add(role);

			return roles;
		}
	}
}
