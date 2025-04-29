using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
               new IdentityRole() { Id = "6a1a2b3c-4d5e-678f-9012-3456789abcde",Name = "User", NormalizedName = "USER" },
               new IdentityRole() { Id = "7b2b3c4d-5e6f-7890-1234-56789abcdef0", Name = "Editor", NormalizedName = "EDITOR" },
               new IdentityRole() { Id = "8c3c4d5e-6f70-8901-2345-6789abcdef01", Name = "Admin", NormalizedName = "ADMIN" }
            );
        }
    }
}